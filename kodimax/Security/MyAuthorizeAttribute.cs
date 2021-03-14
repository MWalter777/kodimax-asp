using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using kodimax.Models;

namespace kodimax.Security
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private Model1 db = new Model1();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {            
            if (string.IsNullOrEmpty(SessionPersister.username) || string.IsNullOrEmpty(SessionPersister.id_usuario))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Usuario", Action = "login" }));
            }
            else
            {
                USUARIO user = db.USUARIO.Find(int.Parse(SessionPersister.id_usuario));

                CustomPrincipal custom = new CustomPrincipal(user);
                if (!custom.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "NoValido", Action = "Index" }));
                }
            }
            //            base.OnAuthorization(filterContext);
        }
    }
}