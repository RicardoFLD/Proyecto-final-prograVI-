using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyecto_final.Models;
using System.Data.Entity;

namespace proyecto_final.Controllers
{
    public class CarreraController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Carrera
        public ActionResult Index()
        {
            var carreras = db.Carreras.Include(r => r.Grado);
            return View(db.Carreras.ToList());
        }
        //Valida el nombre de la carrera
        public JsonResult ValidarNombre(string nombre)
        {
            var existe = db.Carreras.Any(m => m.Nombre == nombre);
            return Json(!existe, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Carreras carrera = db.Carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }
        // GET: Carreras/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Carreras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdentificadorCarrera,Id_Grado,Nombre,Descripcion")] Carreras carrera)
        {
            if (db.Carreras.Any(m => m.Nombre.ToLower() == carrera.Nombre.ToLower()))
            {
                ModelState.AddModelError("Nombre", "El nombre de la carrera ya existe.");
            }
            if (ModelState.IsValid)
            {
                db.Carreras.Add(carrera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrera);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carreras carrera = db.Carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }
        // POST: Carreras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdentificadorCarrera,Id_Grado,Nombre,Descripcion")] Carreras carrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrera);
        }

        // GET: Carreras/Delete/
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carreras carrera = db.Carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }
        // POST: Carreras/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carreras carrera = db.Carreras.Find(id);
            db.Carreras.Remove(carrera);
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