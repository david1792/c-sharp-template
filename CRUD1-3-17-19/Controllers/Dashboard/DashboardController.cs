using CRUD1_3_17_19.AuthData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRUD1_3_17_19.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (CheckSessionUser())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [AllowAnonymous]
        public bool CheckSessionUser()
        {
            if (Session["User"] == null)
            {
                TempData["filter"] = "Robots are laughing non stop index 123123";
                ViewBag.filter = TempData["filter"];
                return false;
            }
            else
            {
                ViewBag.filter = TempData["filter"];
                return true;
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
            return RedirectToAction("Index", "Home");
        }
        [AuthAttribute]
        public ActionResult MyProfile()
        {

            return View();
        }

    }
}