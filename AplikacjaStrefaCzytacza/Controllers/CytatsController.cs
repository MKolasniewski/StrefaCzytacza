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
    public class CytatsController : Controller
    {
        private DbStrefaConfig db = new DbStrefaConfig();

        
        public ActionResult Index()
        {
            var cytats = db.Cytats.Include(c => c.Kategoria);
            return View(cytats.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cytat cytat = db.Cytats.Find(id);
            if (cytat == null)
            {
                return HttpNotFound();
            }
            return View(cytat);
        }

        
        public ActionResult Create()
        {
            ViewBag.KategoriaId = new SelectList(db.Kategorias, "Id", "NazwaKategorii");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KategoriaId,TekstCytatu,NazwaKsiazki,AutorCytatu")] Cytat cytat)
        {
            if (ModelState.IsValid)
            {
                db.Cytats.Add(cytat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriaId = new SelectList(db.Kategorias, "Id", "NazwaKategorii", cytat.KategoriaId);
            return View(cytat);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cytat cytat = db.Cytats.Find(id);
            if (cytat == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriaId = new SelectList(db.Kategorias, "Id", "NazwaKategorii", cytat.KategoriaId);
            return View(cytat);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriaId,TekstCytatu,NazwaKsiazki,AutorCytatu")] Cytat cytat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cytat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriaId = new SelectList(db.Kategorias, "Id", "NazwaKategorii", cytat.KategoriaId);
            return View(cytat);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cytat cytat = db.Cytats.Find(id);
            if (cytat == null)
            {
                return HttpNotFound();
            }
            return View(cytat);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cytat cytat = db.Cytats.Find(id);
            db.Cytats.Remove(cytat);
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
