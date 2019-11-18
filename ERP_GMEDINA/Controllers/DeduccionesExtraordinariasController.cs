﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP_GMEDINA.Models;

namespace ERP_GMEDINA.Controllers
{
    public class DeduccionesExtraordinariasController : Controller
    {
        private ERP_GMEDINAEntities db = new ERP_GMEDINAEntities();

        // GET: DeduccionesExtraordinarias
        public ActionResult Index()
        {
            /*var tbDeduccionesExtraordinarias = db.tbDeduccionesExtraordinarias
                .Select(d => new
                {
                    per_Nombres = d.tbEquipoEmpleados.tbEmpleados.tbPersonas.per_Nombres,
                    per_Apellidos = d.tbEquipoEmpleados.tbEmpleados.tbPersonas.per_Apellidos,
                    dex_MontoInicial = d.dex_MontoInicial,
                    dex_MontoRestante = d.dex_MontoRestante,
                    dex_ObservacionesComentarios = d.dex_ObservacionesComentarios,
                    dex_Cuota = d.dex_Cuota,
                    cde_DescripcionDeduccion = d.tbCatalogoDeDeducciones.cde_DescripcionDeduccion
                })
                .ToList();*/

            var tbDeduccionesExtraordinarias = db.tbDeduccionesExtraordinarias.Where(t => t.dex_Activo == true).Include(t => t.tbUsuario).Include(t => t.tbUsuario1).Include(t => t.tbCatalogoDeDeducciones).Include(t => t.tbEquipoEmpleados);
            return View(tbDeduccionesExtraordinarias.ToList());
        }

        // GET: DeduccionesExtraordinarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDeduccionesExtraordinarias tbDeduccionesExtraordinarias = db.tbDeduccionesExtraordinarias.Find(id);
            if (tbDeduccionesExtraordinarias == null)
            {
                return HttpNotFound();
            }
            return View(tbDeduccionesExtraordinarias);
        }

        // GET: OBTENER LA DATA Y ENVIARLA A LA VISTA EN FORMATO JSON
        public ActionResult GetData()
        {
            //SI SE LLEGA A DAR PROBLEMAS DE "REFERENCIAS CIRCULARES", OBTENER LA DATA DE ESTA FORMA
            //SELECCIONANDO UNO POR UNO LOS CAMPOS QUE NECESITAREMOS
            //DE LO CONTRARIO, HACERLO DE LA FORMA CONVENCIONAL (EJEMPLO: db.tbCatalogoDeDeducciones.ToList(); )

            var tbDeduccionesExtraordinariasD = db.tbDeduccionesExtraordinarias
                .Select(d => new
                {
                    per_Nombres = d.tbEquipoEmpleados.tbEmpleados.tbPersonas.per_Nombres,
                    per_Apellidos = d.tbEquipoEmpleados.tbEmpleados.tbPersonas.per_Apellidos,
                    dex_IdDeduccionesExtra = d.dex_IdDeduccionesExtra,
                    eqem_Id = d.eqem_Id,
                    cde_IdDeducciones = d.cde_IdDeducciones,
                    dex_MontoInicial = d.dex_MontoInicial,
                    dex_MontoRestante = d.dex_MontoRestante,
                    dex_ObservacionesComentarios = d.dex_ObservacionesComentarios,
                    cde_DescripcionDeduccion = d.tbCatalogoDeDeducciones.cde_DescripcionDeduccion,
                    dex_Cuota = d.dex_Cuota,
                    dex_Activo = d.dex_Activo,
                    dex_UsuarioCrea = d.dex_UsuarioCrea,
                    dex_FechaCrea = d.dex_FechaCrea,
                    dex_UsuarioModifica = d.dex_UsuarioModifica,
                    dex_FechaModifica = d.dex_FechaModifica
                }).Where(d => d.dex_Activo == true)
                .ToList();
            //RETORNAR JSON AL LADO DEL CLIENTE
            return new JsonResult { Data = tbDeduccionesExtraordinariasD, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: DeduccionesExtraordinarias/Create
        public ActionResult Create()
        {

            ViewBag.cde_IdDeducciones = new SelectList(db.tbCatalogoDeDeducciones, "cde_IdDeducciones", "cde_DescripcionDeduccion");
            ViewBag.eqem_Id = new SelectList(db.V_DeduccionesExtraordinarias_Detalles, "eqem_Id", "per_Empleado");
            return View();
        }

        // POST: DeduccionesExtraordinarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eqem_Id,dex_MontoInicial,dex_MontoRestante,dex_ObservacionesComentarios,cde_IdDeducciones,dex_Cuota,dex_UsuarioCrea,dex_FechaCrea")] tbDeduccionesExtraordinarias tbDeduccionesExtraordinarias)
        {
            //Para llenar los campos de auditoria
            tbDeduccionesExtraordinarias.dex_UsuarioCrea = 1;
            tbDeduccionesExtraordinarias.dex_FechaCrea = DateTime.Now;
            //Variable para enviarla al lado del Cliente
            string Response = String.Empty;
            IEnumerable<object> listDeduccionesExtraordinarias = null;
            string MensajeError = "";
            if (ModelState.IsValid)
            {
                try
                {
                    //Ejecutar Procedimiento Almacenado
                    listDeduccionesExtraordinarias = db.UDP_Plani_tbDeduccionesExtraordinarias_Insert(tbDeduccionesExtraordinarias.eqem_Id,
                                                                                                      tbDeduccionesExtraordinarias.dex_MontoInicial,
                                                                                                      tbDeduccionesExtraordinarias.dex_MontoRestante,
                                                                                                      tbDeduccionesExtraordinarias.dex_ObservacionesComentarios,
                                                                                                      tbDeduccionesExtraordinarias.cde_IdDeducciones,
                                                                                                      tbDeduccionesExtraordinarias.dex_Cuota,
                                                                                                      tbDeduccionesExtraordinarias.dex_UsuarioCrea,
                                                                                                      tbDeduccionesExtraordinarias.dex_FechaCrea);
                    //El tipo complejo del Procedimiento Almacenado
                    foreach (UDP_Plani_tbDeduccionesExtraordinarias_Insert_Result Resultado in listDeduccionesExtraordinarias)
                    {
                        MensajeError = Resultado.MensajeError;
                    }

                    if (MensajeError.StartsWith("-1"))
                    {
                        //En caso de un error igualamos la variable Response a "Error" para validar en el lado del Cliente
                        ModelState.AddModelError("", "No se pudo Registrar. Contacte al Administrador!");
                        Response = "Error";
                    }
                }
                catch (Exception Ex)
                {
                    Response = Ex.Message.ToString();
                }
                //Si llega aqui significa que todo salio correctamente. Solo igualamos Response a "Exito" para validar en el lado del Cliente
                Response = "Exito";
                return RedirectToAction("Index");

            }
            else
            {
                //Si el modelo no es valido. Igualamos Response a "Error" para validar en el lado del Cliente
                Response = "Error";
            }

            ViewBag.cde_IdDeducciones = new SelectList(db.tbCatalogoDeDeducciones, "cde_IdDeducciones", "cde_DescripcionDeduccion", tbDeduccionesExtraordinarias.cde_IdDeducciones);
            ViewBag.eqem_Id = new SelectList(db.tbEquipoEmpleados, "eqem_Id", "per_Nombres", db.V_DeduccionesExtraordinarias_Detalles.Include(d => d.per_Empleado));
            return Json(Response, JsonRequestBehavior.AllowGet);

        }

        // GET: DeduccionesExtraordinarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDeduccionesExtraordinarias tbDeduccionesExtraordinarias = db.tbDeduccionesExtraordinarias.Find(id);
            if (tbDeduccionesExtraordinarias == null)
            {
                return HttpNotFound();
            }

            ViewBag.cde_IdDeducciones = new SelectList(db.tbCatalogoDeDeducciones, "cde_IdDeducciones", "cde_DescripcionDeduccion", tbDeduccionesExtraordinarias.cde_IdDeducciones);

            //Aqui iria la Vista donde trae al empleado según su Id
            ViewBag.eqem_Id = new SelectList(db.tbEquipoEmpleados, "eqem_Id", "per_Empleado", db.V_DeduccionesExtraordinarias_Detalles.Include(d => d.per_Empleado));
            return View(tbDeduccionesExtraordinarias);
        }

        // POST: DeduccionesExtraordinarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dex_IdDeduccionesExtra,eqem_Id,dex_MontoInicial,dex_MontoRestante,dex_ObservacionesComentarios,cde_IdDeducciones,dex_Cuota,dex_UsuarioModifica,dex_FechaModifica")] tbDeduccionesExtraordinarias tbDeduccionesExtraordinarias)
        {
            //Para llenar los campos de auditoria
            tbDeduccionesExtraordinarias.dex_UsuarioModifica = 1;
            tbDeduccionesExtraordinarias.dex_FechaModifica = DateTime.Now;
            //Variable para enviarla al lado del Cliente
            string Response = String.Empty;
            IEnumerable<object> listDeduccionesExtraordinarias = null;
            string MensajeError = "";
            if (ModelState.IsValid)
            {
                try
                {
                    //Ejecutar Procedimiento Almacenado
                    listDeduccionesExtraordinarias = db.UDP_Plani_tbDeduccionesExtraordinarias_Update(tbDeduccionesExtraordinarias.dex_IdDeduccionesExtra,
                                                                                                      tbDeduccionesExtraordinarias.eqem_Id,
                                                                                                      tbDeduccionesExtraordinarias.dex_MontoInicial,
                                                                                                      tbDeduccionesExtraordinarias.dex_MontoRestante,
                                                                                                      tbDeduccionesExtraordinarias.dex_ObservacionesComentarios,
                                                                                                      tbDeduccionesExtraordinarias.cde_IdDeducciones,
                                                                                                      tbDeduccionesExtraordinarias.dex_Cuota,
                                                                                                      tbDeduccionesExtraordinarias.dex_UsuarioModifica,
                                                                                                      tbDeduccionesExtraordinarias.dex_FechaModifica);

                    //El tipo complejo del Procedimiento Almacenado
                    foreach (UDP_Plani_tbDeduccionesExtraordinarias_Update_Result Resultado in listDeduccionesExtraordinarias)
                    {
                        MensajeError = Resultado.MensajeError;
                    }

                    if (MensajeError.StartsWith("-1"))
                    {
                        //En caso de un error igualamos la variable Response a "Error" para validar en el lado del Cliente
                        ModelState.AddModelError("", "No se pudo Actualizar. Contacte al Administrador!");
                        Response = "Error";
                    }
                }
                catch (Exception Ex)
                {
                    Response = Ex.Message.ToString();
                }
                //Si llega aqui significa que todo salio correctamente. Solo igualamos Response a "Exito" para validar en el lado del Cliente
                Response = "Exito";
                return RedirectToAction("Index");
            }
            else
            {
                //Si el modelo no es valido. Igualamos Response a "Error" para validar en el lado del Cliente
                Response = "Error";
            }

            ViewBag.cde_IdDeducciones = new SelectList(db.tbCatalogoDeDeducciones, "cde_IdDeducciones", "cde_DescripcionDeduccion", tbDeduccionesExtraordinarias.cde_IdDeducciones);
            ViewBag.eqem_Id = new SelectList(db.tbEquipoEmpleados, "eqem_Id", "per_Nombres", db.V_DeduccionesExtraordinarias_Detalles.Include(d => d.per_Empleado));
            return Json(Response, JsonRequestBehavior.AllowGet);

        }

        //FUNCIÓN: OBETENER LA DATA PARA LLENAR LOS DROPDOWNLIST DE EDICIÓN Y CREACIÓN
        public JsonResult EditGetDDL()
        {
            //OBTENER LA DATA QUE NECESITAMOS, HACIENDOLO DE ESTA FORMA SE EVITA LA EXCEPCION POR "REFERENCIAS CIRCULARES"
            var DDL =
            from EqEm in db.tbEquipoEmpleados
            join Empl in db.tbEmpleados on EqEm.emp_Id equals Empl.emp_Id
            join Pers in db.tbPersonas on Empl.per_Id equals Pers.per_Id
            select new { Id = EqEm.eqem_Id , Nombre = Pers.per_Nombres };
            //RETORNAR LA DATA EN FORMATO JSON AL CLIENTE 
            return Json(DDL, JsonRequestBehavior.AllowGet);
        }


        //GET: DeduccionesExtraordinarias/Inactivar
        public ActionResult Inactivar(int? ID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            tbDeduccionesExtraordinarias tbDeduccionesExtraordinariasJSON = db.tbDeduccionesExtraordinarias.Find(ID);
            return Json(tbDeduccionesExtraordinariasJSON, JsonRequestBehavior.AllowGet);
        }


        //POST: DeduccionesExtraordinarias/Inactivar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inactivar(int dex_IdDeduccionesExtra)
        {
            //Para llenar los campos de auditoria
            //tbDeduccionesExtraordinarias.dex_UsuarioModifica = 1;
            //tbDeduccionesExtraordinarias.dex_FechaModifica = DateTime.Now;
            //Variable para enviarla al lado del Cliente
            string Response = String.Empty;
            IEnumerable<object> listDeduccionesExtraordinarias = null;
            string MensajeError = "";
            if (ModelState.IsValid)
            {
                try
                {
                    //Ejecutar Procedimiento Almacenado
                    listDeduccionesExtraordinarias = db.UDP_Plani_tbDeduccionesExtraordinarias_Inactivar(dex_IdDeduccionesExtra,
                                                                                                         1,
                                                                                                         DateTime.Now);

                    //El tipo complejo del Procedimiento Almacenado
                    foreach (UDP_Plani_tbDeduccionesExtraordinarias_Inactivar_Result Resultado in listDeduccionesExtraordinarias)
                    {
                        MensajeError = Resultado.MensajeError;
                    }

                    if (MensajeError.StartsWith("-1"))
                    {
                        //En caso de un error igualamos la variable Response a "Error" para validar en el lado del Cliente
                        ModelState.AddModelError("", "No se pudo Inactivar. Contacte al Administrador!");
                        Response = "Error";
                    }
                }
                catch (Exception Ex)
                {
                    Response = Ex.Message.ToString();
                }
                //Si llega aqui significa que todo salio correctamente. Solo igualamos Response a "Exito" para validar en el lado del Cliente
                Response = "Exito";
            }
            else
            {
                //Si el modelo no es valido. Igualamos Response a "Error" para validar en el lado del Cliente
                Response = "Error";
            }

            return Json(Response, JsonRequestBehavior.AllowGet);

        }

        // GET: DeduccionesExtraordinarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDeduccionesExtraordinarias tbDeduccionesExtraordinarias = db.tbDeduccionesExtraordinarias.Find(id);
            if (tbDeduccionesExtraordinarias == null)
            {
                return HttpNotFound();
            }
            return View(tbDeduccionesExtraordinarias);
        }

        // POST: DeduccionesExtraordinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbDeduccionesExtraordinarias tbDeduccionesExtraordinarias = db.tbDeduccionesExtraordinarias.Find(id);
            db.tbDeduccionesExtraordinarias.Remove(tbDeduccionesExtraordinarias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}