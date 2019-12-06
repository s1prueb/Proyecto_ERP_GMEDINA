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
    public class SeleccionCandidatosController : Controller
    {
        private ERP_GMEDINAEntities db = new ERP_GMEDINAEntities();

        // GET: SeleccionCandidatos
        public ActionResult Index()
        {
            Session["Usuario"] = new tbUsuario { usu_Id = 1 };
            var tbSeleccionCandidatos = new List<tbSeleccionCandidatos> { };
            return View(tbSeleccionCandidatos);
        }
        public ActionResult llenarTabla()
        {
            try
            {
                //declaramos la variable de coneccion solo para recuperar los datos necesarios.
                //posteriormente es destruida.
                using (db = new ERP_GMEDINAEntities())
                {
                    var tbSeleccionCandidatos = db.V_SeleccionCandidatos
                        .Select(
                        t => new
                        {
                          
                            per_Identidad = t.Identidad,
                            per_Nombres = t.Nombre,
                            fare_Descripcion = t.Fase,
                            req_Descripcion = t.Plaza_Disponible,
                            scan_Fecha = t.Fecha
                            
                        }
                        )
                        .ToList();
                    return Json(tbSeleccionCandidatos, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("-2", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ChildRowData(int? id)
        {
            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
            //posteriormente es destruida.
            List<V_SeleccionCandidatos> lista = new List<V_SeleccionCandidatos> { };
            using (db = new ERP_GMEDINAEntities())
            {
                try
                {
                    lista = db.V_SeleccionCandidatos.Where(x => x.Id == id).ToList();
                }
                catch
                {
                }
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public ActionResult llenarDropDowlist()
        {
            var Identidad = new List<object> { };
            using (db = new ERP_GMEDINAEntities())
            {
                try
                {
                    Identidad.Add(new
                    {
                        Id = 0,
                        Descripcion = "**Seleccione una opción**"
                    });
                    Identidad.AddRange(db.tbPersonas
                    .Select(tabla => new { Id = tabla.per_Id, Descripcion = tabla.per_Identidad })
                    .ToList());
                }
                catch
                {
                    return Json("-2", 0);
                }



            }
            var result = new Dictionary<string, object>();
            result.Add("Identidad", Identidad);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: Areas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
            //posteriormente es destruida.
            tbSeleccionCandidatos tbSeleccionCandidatos = null;
            using (db = new ERP_GMEDINAEntities())
            {
                try
                {
                    tbSeleccionCandidatos = db.tbSeleccionCandidatos.Find(id);
                }
                catch
                {



                }
            }
            if (tbSeleccionCandidatos == null)
            {
                return HttpNotFound();
            }
            return View(tbSeleccionCandidatos);
        }
        // GET: Areas/Create
//        public ActionResult Create()
//        {
//            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
//            //posteriormente es destruida.
//            List<tbSucursales> Sucursales = new List<tbSucursales> { };
//            ViewBag.suc_Id = new SelectList(Sucursales, "suc_Id", "suc_Descripcion");
//            return View();
//        }
//        // POST: Areas/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        public ActionResult Create(tbAreas tbAreas, tbDepartamentos[] tbDepartamentos)
//        {
//            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
//            //posteriormente es destruida.
//            string result = "";
//            //en esta area ingresamos el registro con el procedimiento almacenado
//            try
//            {
//                if (tbAreas.suc_Id == 0 || tbAreas.tbCargos.car_Descripcion == "" || tbAreas.area_Descripcion == "")
//                {
//                    return Json("-2", JsonRequestBehavior.AllowGet);
//                }
//                foreach (var item in tbDepartamentos)
//                {
//                    if (item.depto_Descripcion == "" || item.tbCargos.car_Descripcion == "")
//                    {
//                        return Json("-2", JsonRequestBehavior.AllowGet);
//                    }
//                }
//                var Usuario = (tbUsuario)Session["Usuario"];
//                using (var scope = new TransactionScope())
//                {
//                    using (db = new ERP_GMEDINAEntities())
//                    {
//                        var list = db.UDP_RRHH_tbAreas_Insert(
//                                                                tbAreas.suc_Id,
//                                                                tbAreas.tbCargos.car_Descripcion,
//                                                                tbAreas.area_Descripcion,
//                                                                Usuario.usu_Id,
//                                                                DateTime.Now);
//                        foreach (UDP_RRHH_tbAreas_Insert_Result item in list)
//                        {
//                            tbAreas.area_Id = int.Parse(item.MensajeError.ToString());
//                        }
//                        if (tbAreas.area_Id == -2)
//                        {
//                            return Json("-2", JsonRequestBehavior.AllowGet);
//                        }
//                        foreach (var item in tbDepartamentos)
//                        {

//                        }



//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                ex.Message.ToString();
//                result = "-2";
//            }
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }
//        // GET: Areas/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
//            //posteriormente es destruida.
//            tbAreas tbAreas = null;
//            using (db = new ERP_GMEDINAEntities())
//            {
//                List<tbSucursales> Sucursales = null;
//                try
//                {
//                    tbAreas = db.tbAreas.Find(id);
//                    Sucursales = db.tbSucursales.ToList();
//                    ViewBag.suc_Id = new SelectList(Sucursales, "suc_Id", "suc_Descripcion");
//                }
//                catch
//                {
//                }
//            }
//            if (tbAreas == null)
//            {
//                return HttpNotFound();
//            }
//            return View(new cAreas
//            {
//                suc_Id = tbAreas.suc_Id,
//                area_Descripcion = tbAreas.area_Descripcion
//            });
//        }
//        // POST: Areas/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        public ActionResult Edit([Bind(Include = "area_Id,car_Id,suc_Id,area_Descripcion,area_Estado,area_Razoninactivo,area_Usuariocrea,area_Fechacrea,area_Usuariomodifica,area_Fechamodifica")] tbAreas tbAreas)
//        {
//            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
//            //posteriormente es destruida.
//            string result = "";
//            using (db = new ERP_GMEDINAEntities())
//            {
//                try
//                {
//                    //en esta area actualizamos el registro con el procedimiento almacenado
//                }
//                catch
//                {
//                    result = "-2";
//                }
//            }
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }
//        // POST: Areas/Delete/5

//[HttpPost]
//        public ActionResult Delete(int? id)
//        {
//            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
//            //posteriormente es destruida.
//            string result = "";
//            using (db = new ERP_GMEDINAEntities())
//            {
//                try
//                {
//                    //en esta area Inavilitamos el registro con el procedimiento almacenado
//                }
//                catch
//                {
//                    result = "-2";
//                }
//            }
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}




