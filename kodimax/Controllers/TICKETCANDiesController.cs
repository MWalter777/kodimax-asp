using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kodimax.Models;

namespace kodimax.Controllers
{
    public class TICKETCANDiesController : Controller
    {
        private Model1 db = new Model1();

        // GET: TICKETCANDies
        public ActionResult Index()
        {
            return View(db.TICKETCANDies.ToList());
        }

        // GET: TICKETCANDies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETCANDY tICKETCANDY = db.TICKETCANDies.Find(id);
            if (tICKETCANDY == null)
            {
                return HttpNotFound();
            }
            return View(tICKETCANDY);
        }

        // GET: TICKETCANDies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TICKETCANDies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIKET_CANDY,ID_CANDY,PAY")] TICKETCANDY tICKETCANDY)
        {
            if (ModelState.IsValid)
            {
                db.TICKETCANDies.Add(tICKETCANDY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tICKETCANDY);
        }

        // GET: TICKETCANDies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETCANDY tICKETCANDY = db.TICKETCANDies.Find(id);
            if (tICKETCANDY == null)
            {
                return HttpNotFound();
            }
            return View(tICKETCANDY);
        }

        // POST: TICKETCANDies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIKET_CANDY,ID_CANDY,PAY")] TICKETCANDY tICKETCANDY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKETCANDY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tICKETCANDY);
        }

        // GET: TICKETCANDies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETCANDY tICKETCANDY = db.TICKETCANDies.Find(id);
            if (tICKETCANDY == null)
            {
                return HttpNotFound();
            }
            return View(tICKETCANDY);
        }

        // POST: TICKETCANDies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TICKETCANDY tICKETCANDY = db.TICKETCANDies.Find(id);
            db.TICKETCANDies.Remove(tICKETCANDY);
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
