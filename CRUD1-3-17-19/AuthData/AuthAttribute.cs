using CRUD1_3_17_19.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace CRUD1_3_17_19.AuthData
{
    public class AuthAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        private bool _auth;
        private bool _HasPermission = false;
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            var url = filterContext.HttpContext.Request.RawUrl;
            System.Diagnostics.Debug.WriteLine("------------------------------------------------"+ url);
            _auth = (filterContext.ActionDescriptor.GetCustomAttributes(typeof(OverrideActionFiltersAttribute), true).Length == 0);
            if (filterContext.HttpContext.Session["user"] != null)
            {
                if (filterContext.HttpContext.Session["rolpermisos"] != null )
                {
                    var listaRoles = (List<ROLES_PERMISOS>)filterContext.HttpContext.Session["rolpermisos"];
                    var listaPermisos = (List<PERMISOS>)filterContext.HttpContext.Session["permisos"];
                    if (listaPermisos.Count <= 0)
                    {
                        filterContext.Controller.TempData["filter"] += "No tiene permiso asignados, info al admin";
                        var routeValues = new RouteValueDictionary(new
                        {
                            controller = "Home",
                            action = "SignOut"
                        });
                        filterContext.Result = new RedirectToRouteResult(routeValues);
                        return;
                    }
                    else
                    {
                        foreach (var item in listaPermisos)
                        {
                            if (string.Equals(item.URL, url) || item.URL.Contains(url))
                            {
                                _HasPermission = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    filterContext.Controller.TempData["filter"] += "No tiene rol asignado, info al admin";
                    var routeValues = new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "SignOut"
                    });
                    filterContext.Result = new RedirectToRouteResult(routeValues);
                    return;

                }
                if (!_HasPermission)
                {
                    filterContext.Controller.TempData["filter"] += "No tiene vista asignada, info al admin";
                    var routeValues = new RouteValueDictionary(new
                    {
                        controller = "Dashboard",
                        action = "Index"
                    });
                    filterContext.Result = new RedirectToRouteResult(routeValues);
                    return;
                }
            } else
            {
                filterContext.Controller.TempData["filter"] += "Robots are laughing non stop";
                var routeValues = new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                });
                filterContext.Result = new RedirectToRouteResult(routeValues);
                return;
            }
            System.Diagnostics.Debug.WriteLine("------------------------------------------------");
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            /*var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                System.Diagnostics.Debug.WriteLine("fuera prro , no haz iniciado");
                //filterContext.Result = new HttpUnauthorizedResult();
            }*/
        }
    }
}