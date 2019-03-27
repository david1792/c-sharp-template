 using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD1_3_17_19.AuthData;
using CRUD1_3_17_19.Models;

namespace CRUD1_3_17_19.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["filter"] != null)
            {

                ViewBag.AuthFilterMessage += " " + TempData["filter"];
            }

            return View();
        }
        [HttpPost]
        public ActionResult Index(ALUMNO alumno)
        {
            if (ModelState.IsValid)
            {
                using (ALUMNOS_DBContext db = new ALUMNOS_DBContext())
                {
                    List<PERMISOS> lista = new List<PERMISOS>();
                    var queryAlumno = (from a in db.ALUMNO
                                where a.NOMBRES == alumno.NOMBRES && a.APELLIDOS == alumno.APELLIDOS
                                select a).FirstOrDefault();
                    if (queryAlumno != null)
                    {
                        var queryRoles = (from t1 in db.ROLES
                                          where t1.ID == queryAlumno.ROLES_ID
                                          select t1).FirstOrDefault();
                        var queryRolesPermisos = (from t1 in db.ROLES_PERMISOS
                                                 join t2 in db.PERMISOS on t1.PERMISOS.ID equals t2.ID
                                                 where t1.ROL_ID == queryRoles.ID
                                                 select t1).ToList();
                        foreach (var item in queryRolesPermisos)
                        {
                            lista.Add((from t1 in db.PERMISOS.Include("PERMISOS1")//EAGER LOAD SUBPERMISOS
                                       where t1.ID == item.ID
                                       select t1).FirstOrDefault());
                            System.Diagnostics.Debug.WriteLine(item.ID);
                        }
                        Session["user"] = queryAlumno;
                        Session["rol"] = queryRoles;
                        Session["rolpermisos"] = queryRolesPermisos.ToList();
                        Session["permisos"] = lista.ToList();
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ViewBag.message = "usuario no existe en la BD";
                        return View();
                    }
                }
            }
            else
            {
                ViewBag.message = "Rellene el formulario";
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult SignOut()
        {
            ViewBag.filter = TempData["filter"];
            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }
    }
}