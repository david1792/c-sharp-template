using CRUD1_3_17_19.AuthData;
using CRUD1_3_17_19.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CRUD1_3_17_19.Controllers
{
    [AuthAttribute]
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            ALUMNOS_DBContext db = new ALUMNOS_DBContext();//nombre que se le dio al contecto al crearlo con EF
            return View(db.ALUMNO.Where(a => a.EDAD > 5 && a.EDAD <= 18).ToList());
            /*var query = from a in db.ALUMNO
                        where a.EDAD > 5 && a.EDAD <= 18
                        select new
                        {
                            NOMBRE = a.NOMBRES,
                            APELLIDOS = a.APELLIDOS,
                            EDAD = a.EDAD,
                            FECHA_REGISTRO = a.FECHA_REGISTRO,
                            ID = a.ID,
                            SEXO = a.SEXO
                        };
            return View(query);*/
        }
        public ActionResult CreateOrEdit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(ALUMNO a)
        {
            a.SEXO = null;
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new ALUMNOS_DBContext())
                {
                    db.ALUMNO.Add(a);//crea el usuario
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                ModelState.AddModelError("",  sb.ToString());
                return View();
            }
        }
        public ActionResult Editar(int id)
        {
            //si unsamos ajax, tenemos que retornal un jsonResult y la funcuion debe retornar ese tipo de dato
            using (var db = new ALUMNOS_DBContext())
            {
                var al1 = db.ALUMNO.Where(a => a.ID == id).FirstOrDefault();//el where es multiproposito y mas comun
                var al2 = db.ALUMNO.Find(id);//solo se usa cuando tenga una sola llave primaria ya que si tiene una clave compuesta el EF lanza un error
                return View(al1);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ALUMNO alumno)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new ALUMNOS_DBContext())
            {
                ALUMNO al = db.ALUMNO.Where(a => a.ID == alumno.ID).FirstOrDefault();
                al.NOMBRES = alumno.NOMBRES;
                al.APELLIDOS = alumno.APELLIDOS;
                al.EDAD = alumno.EDAD;
                al.SEXO = alumno.SEXO;
                db.SaveChanges();
                return RedirectToAction("Index", "Alumno");
            }
        }
        public ActionResult Detalle(int id)
        {
            //caso que lo mismo que editar
            using (var db = new ALUMNOS_DBContext())
            {
                var al1 = db.ALUMNO.Where(a => a.ID == id).FirstOrDefault();
                return View(al1);
            }
        }
        public ActionResult Borrar(int id)
        {
            //caso que lo mismo que editar
            using (var db = new ALUMNOS_DBContext())
            {
                var al1 = db.ALUMNO.Where(a => a.ID == id).FirstOrDefault();
                db.ALUMNO.Remove(al1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}

