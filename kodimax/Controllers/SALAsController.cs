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
    public class SALAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: SALAs
        public ActionResult Index()
        {
            return View(db.SALAs.ToList());
        }

        // GET: SALAs/Details/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = db.SALAs.Find(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // GET: SALAs/Create
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Create([Bind(Include = "ID_SALA,NAME,PRICE,QUANTIY")] SALA sALA)
        {
            if (ModelState.IsValid)
            {
                db.SALAs.Add(sALA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALA);
        }

        // GET: SALAs/Edit/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = db.SALAs.Find(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // POST: SALAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Edit([Bind(Include = "ID_SALA,NAME,PRICE,QUANTIY")] SALA sALA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALA);
        }

        // GET: SALAs/Delete/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = db.SALAs.Find(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // POST: SALAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            SALA sALA = db.SALAs.Find(id);
            db.SALAs.Remove(sALA);
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
