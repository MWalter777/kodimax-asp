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
    public class candiesController : Controller
    {
        private Model1 db = new Model1();

        // GET: candies
        [MyAuthorize(Roles = "administrador,empleado")]
        public ActionResult Index()
        {
            return View(db.candies.ToList());
        }

        // GET: candies/Details/5
        [MyAuthorize(Roles = "administrador,empleado")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candy candy = db.candies.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            return View(candy);
        }

        // GET: candies/Create
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: candies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,type,price,image")] candy candy)
        {
            if (ModelState.IsValid)
            {
                db.candies.Add(candy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candy);
        }

        // GET: candies/Edit/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candy candy = db.candies.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            return View(candy);
        }

        // POST: candies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,type,price,image")] candy candy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candy);
        }

        // GET: candies/Delete/5
        [MyAuthorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candy candy = db.candies.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            return View(candy);
        }

        // POST: candies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            candy candy = db.candies.Find(id);
            db.candies.Remove(candy);
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
