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
    public class MoviesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.MOVIEs.ToList());
        }

        // GET: Movies/Details/5
        [MyAuthorize(Roles = "administrador, empleado")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = db.MOVIEs.Find(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // GET: Movies/Create
        [MyAuthorize(Roles = "administrador, empleado")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador, empleado")]
        public ActionResult Create([Bind(Include = "ID_MOVIE,NAME,TIME,TYPE,IMAGE")] MOVIE mOVIE)
        {
            if (ModelState.IsValid)
            {
                db.MOVIEs.Add(mOVIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mOVIE);
        }

        // GET: Movies/Edit/5
        [MyAuthorize(Roles = "administrador, empleado")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = db.MOVIEs.Find(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // POST: Movies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [MyAuthorize(Roles = "administrador, empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MOVIE,NAME,TIME,TYPE,IMAGE")] MOVIE mOVIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mOVIE);
        }

        // GET: Movies/Delete/5
        [MyAuthorize(Roles = "administrador, empleado")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIE mOVIE = db.MOVIEs.Find(id);
            if (mOVIE == null)
            {
                return HttpNotFound();
            }
            return View(mOVIE);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador, empleado")]
        public ActionResult DeleteConfirmed(int id)
        {
            MOVIE mOVIE = db.MOVIEs.Find(id);
            db.MOVIEs.Remove(mOVIE);
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
