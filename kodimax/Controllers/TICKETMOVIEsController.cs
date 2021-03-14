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
    public class TICKETMOVIEsController : Controller
    {
        private Model1 db = new Model1();

        // GET: TICKETMOVIEs
        public ActionResult Index()
        {
            var tICKETMOVIEs = db.TICKETMOVIEs.Include(t => t.movie).Include(t => t.sala);
            return View(tICKETMOVIEs.ToList());
        }

        // GET: TICKETMOVIEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETMOVIE tICKETMOVIE = db.TICKETMOVIEs.Find(id);
            if (tICKETMOVIE == null)
            {
                return HttpNotFound();
            }
            return View(tICKETMOVIE);
        }

        // GET: TICKETMOVIEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_MOVIE = new SelectList(db.MOVIEs, "ID_MOVIE", "NAME");
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "NAME");
            return View();
        }

        // POST: TICKETMOVIEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_MOVIE,ID_SALA,CANT_BUTACA,TYPE")] TICKETMOVIE tICKETMOVIE)
        {
            ViewBag.ID_MOVIE = new SelectList(db.MOVIEs, "ID_MOVIE", "NAME", tICKETMOVIE.ID_MOVIE);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "NAME", tICKETMOVIE.ID_SALA);
            if (ModelState.IsValid)
            {
                db.TICKETMOVIEs.Add(tICKETMOVIE);
                db.SaveChanges();
                ViewBag.total = db.SALAs.Find(tICKETMOVIE.ID_SALA).PRICE * tICKETMOVIE.CANT_BUTACA;
                return View();
            }
            return View(tICKETMOVIE);
        }

        // GET: TICKETMOVIEs/Edit/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETMOVIE tICKETMOVIE = db.TICKETMOVIEs.Find(id);
            if (tICKETMOVIE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MOVIE = new SelectList(db.MOVIEs, "ID_MOVIE", "NAME", tICKETMOVIE.ID_MOVIE);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "NAME", tICKETMOVIE.ID_SALA);
            return View(tICKETMOVIE);
        }

        // POST: TICKETMOVIEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Edit([Bind(Include = "ID,ID_MOVIE,ID_SALA,CANT_BUTACA,TYPE")] TICKETMOVIE tICKETMOVIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKETMOVIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MOVIE = new SelectList(db.MOVIEs, "ID_MOVIE", "NAME", tICKETMOVIE.ID_MOVIE);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "NAME", tICKETMOVIE.ID_SALA);
            return View(tICKETMOVIE);
        }

        // GET: TICKETMOVIEs/Delete/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETMOVIE tICKETMOVIE = db.TICKETMOVIEs.Find(id);
            if (tICKETMOVIE == null)
            {
                return HttpNotFound();
            }
            return View(tICKETMOVIE);
        }

        // POST: TICKETMOVIEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [MyAuthorize(Roles = "administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            TICKETMOVIE tICKETMOVIE = db.TICKETMOVIEs.Find(id);
            db.TICKETMOVIEs.Remove(tICKETMOVIE);
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
