using kodimax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kodimax.Security;

namespace kodimax.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            // Para fines de prueba, no quiero estar metiendo estos roles directamente en la db
            if (db.ROL.ToList().Count < 1)
            {
                ROL rol1 = new ROL();
                rol1.NOMBRE_ROL = "administrador";
                rol1.DESCRIPCION_ROL = "administrador";
                db.ROL.Add(rol1);
                ROL rol2 = new ROL();
                rol2.NOMBRE_ROL = "empleado";
                rol2.DESCRIPCION_ROL = "empleado";
                db.ROL.Add(rol2);
                ROL rol3 = new ROL();
                rol3.NOMBRE_ROL = "usuario";
                rol3.DESCRIPCION_ROL = "usuario";
                db.ROL.Add(rol3);
                db.SaveChanges();
                ROL rol = db.ROL.ToList().Where(r => r.NOMBRE_ROL == "administrador").First();
                if (rol != null)
                {
                    USUARIO usuario = new USUARIO();
                    usuario.EMAIL = "kodimax@gmail.com";
                    usuario.HABILITADO = true;
                    usuario.PASSWORD = Encode.EncodePassword("@dminM@x");
                    usuario.USERNAME = "admin-max";
                    usuario.ID_ROL = rol.ID_ROL;
                    db.USUARIO.Add(usuario);
                    db.SaveChanges();
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}