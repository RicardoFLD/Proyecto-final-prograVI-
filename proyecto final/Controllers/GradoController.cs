using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_final.Controllers
{
    public class GradoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View(db.Grados.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Grados.Add(grado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grado);
        }

        public ActionResult Edit(int id)
        {
            var grado = db.Grados.Find(id);
            if (grado == null) return HttpNotFound();
            return View(grado);
        }

        [HttpPost]
        public ActionResult Edit(Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grado);
        }

        public ActionResult Delete(int id)
        {
            var grado = db.Grados.Find(id);
            if (grado == null) return HttpNotFound();
            return View(grado);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var grado = db.Grados.Find(id);
            if (grado != null)
            {
                db.Grados.Remove(grado);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}