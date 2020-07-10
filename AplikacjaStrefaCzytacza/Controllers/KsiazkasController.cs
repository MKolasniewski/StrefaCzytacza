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
    public class KsiazkasController : Controller
    {
        private DbStrefaConfig db = new DbStrefaConfig();


        public ActionResult Index()
        {
            var ksiazkas = db.Ksiazkas.Include(k => k.Kategoria);
            return View(ksiazkas.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazkas.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }


        public ActionResult Create()
        {
            ViewBag.KategoriaId = new SelectList(db.Kategorias, "Id", "NazwaKategorii");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KategoriaId,NazwaKsiazki,OpisKsiazki,Autorksiazki,OcenaKsiazki")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Ksiazkas.Add(ksiazka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriaId = new SelectList(db.Kategorias, "Id", "NazwaKategorii", ksiazka.KategoriaId);
            return View(ksiazka);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazkas.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriaId = new SelectList(db.Kategorias, "Id", "NazwaKategorii", ksiazka.KategoriaId);
            return View(ksiazka);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriaId,NazwaKsiazki,OpisKsiazki,Autorksiazki,OcenaKsiazki")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiazka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriaId = new SelectList(db.Kategorias, "Id", "NazwaKategorii", ksiazka.KategoriaId);
            return View(ksiazka);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazkas.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ksiazka ksiazka = db.Ksiazkas.Find(id);
            db.Ksiazkas.Remove(ksiazka);
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
