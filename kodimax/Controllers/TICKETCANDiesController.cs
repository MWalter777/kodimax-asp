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
    public class TICKETCANDiesController : Controller
    {
        private Model1 db = new Model1();

        // GET: TICKETCANDies
        public ActionResult Index()
        {
            var tICKETCANDies = db.TICKETCANDies.Include(t => t.candy);
            return View(tICKETCANDies.ToList());
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
            ViewBag.ID_CANDY = new SelectList(db.CANDies, "ID_CANDY", "NAME");
            return View();
        }

        // POST: TICKETCANDies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIKET_CANDY,ID_CANDY,PAY")] TICKETCANDY tICKETCANDY)
        {
            ViewBag.ID_CANDY = new SelectList(db.CANDies, "ID_CANDY", "NAME", tICKETCANDY.ID_CANDY);
            if (ModelState.IsValid)
            {
                db.TICKETCANDies.Add(tICKETCANDY);
                db.SaveChanges();
                ViewBag.total = db.CANDies.Find(tICKETCANDY.ID_CANDY).PRICE * tICKETCANDY.PAY;
                ViewBag.empleado = db.USUARIO.ToList().First().USERNAME;
                return View();
            }
            return View(tICKETCANDY);
        }

        // GET: TICKETCANDies/Edit/5
        [MyAuthorize(Roles = "administrador")]
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
            ViewBag.ID_CANDY = new SelectList(db.CANDies, "ID_CANDY", "NAME", tICKETCANDY.ID_CANDY);
            return View(tICKETCANDY);
        }

        // POST: TICKETCANDies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Edit([Bind(Include = "ID_TIKET_CANDY,ID_CANDY,PAY")] TICKETCANDY tICKETCANDY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKETCANDY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CANDY = new SelectList(db.CANDies, "ID_CANDY", "NAME", tICKETCANDY.ID_CANDY);
            return View(tICKETCANDY);
        }

        // GET: TICKETCANDies/Delete/5
        [MyAuthorize(Roles = "administrador")]
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
        [MyAuthorize(Roles = "administrador")]
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
