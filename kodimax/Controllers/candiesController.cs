using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kodimax.Models;
using kodimax.Security;

namespace kodimax.Controllers
{
    public class CANDiesController : Controller
    {
        private Model1 db = new Model1();

        // GET: CANDies
        public ActionResult Index()
        {
            return View(db.CANDies.ToList());
        }

        // GET: CANDies/Details/5
        [MyAuthorize(Roles = "administrador,empleado")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDY cANDY = db.CANDies.Find(id);
            if (cANDY == null)
            {
                return HttpNotFound();
            }
            return View(cANDY);
        }

        // GET: CANDies/Create
        [MyAuthorize(Roles = "administrador,empleado")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CANDies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador,empleado")]
        public ActionResult Create([Bind(Include = "ID_CANDY,NAME,TYPE,PRICE,IMAGE")] CANDY cANDY)
        {
            if (ModelState.IsValid)
            {
                db.CANDies.Add(cANDY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cANDY);
        }

        // GET: CANDies/Edit/5
        [MyAuthorize(Roles = "administrador,empleado")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDY cANDY = db.CANDies.Find(id);
            if (cANDY == null)
            {
                return HttpNotFound();
            }
            return View(cANDY);
        }

        // POST: CANDies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador,empleado")]
        public ActionResult Edit([Bind(Include = "ID_CANDY,NAME,TYPE,PRICE,IMAGE")] CANDY cANDY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANDY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cANDY);
        }

        [MyAuthorize(Roles = "administrador,empleado")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDY cANDY = db.CANDies.Find(id);
            if (cANDY == null)
            {
                return HttpNotFound();
            }
            return View(cANDY);
        }

        // POST: CANDies/Delete/5
        [MyAuthorize(Roles = "administrador,empleado")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CANDY cANDY = db.CANDies.Find(id);
            db.CANDies.Remove(cANDY);
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
