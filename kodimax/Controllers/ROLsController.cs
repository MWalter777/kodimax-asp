using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using kodimax.Models;
using kodimax.Security;
using EntityState = System.Data.Entity.EntityState;

namespace kodimax.Controllers
{
    public class ROLsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ROLs
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Index()
        {
            return View(db.ROL.ToList());
        }

        // GET: ROLs/Details/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // GET: ROLs/Create
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Create()
        {
            return View();
        }

        [MyAuthorize(Roles = "administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                db.ROL.Add(rOL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rOL);
        }

        // GET: ROLs/Edit/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }

            return View(rOL);
        }


        [MyAuthorize(Roles = "administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ROL,NOMBRE_ROL,DESCRIPCION_ROL")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rOL);
        }

        // GET: ROLs/Delete/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: ROLs/Delete/5
        [MyAuthorize(Roles = "administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ROL rOL = db.ROL.Find(id);
            db.ROL.Remove(rOL);
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
