using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplikacjaStrefaCzytacza.DAL;
using AplikacjaStrefaCzytacza.Models;

namespace AplikacjaStrefaCzytacza.Controllers
{
    public class KategoriasController : Controller
    {
        private DbStrefaConfig db = new DbStrefaConfig();


        public ActionResult Index()
        {
            return View(db.Kategorias.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorias.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazwaKategorii,OpisKategorii")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Kategorias.Add(kategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoria);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorias.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazwaKategorii,OpisKategorii")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoria);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorias.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategoria kategoria = db.Kategorias.Find(id);
            db.Kategorias.Remove(kategoria);
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
