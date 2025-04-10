using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using proyecto_final.Models;

namespace proyecto_final.Controllers
{
    public class MateriasController : Controller
    {
        private AppDbContext db = new AppDbContext();
    // GET: Materias
    public ActionResult Index()
    {
        return View(db.Materias.ToList());
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
        Materia materia = db.Materias.Find(id);
        if (materia == null)
        {
            return HttpNotFound();
        }
        return View(materia);
    }

    // GET: Materias/Create
    public ActionResult Create()
    {
        return View();
    }

    //Post: Materias/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "IdentificadorMateria,Nombre,Codigo,NumeroCreditos,NumeroHoras")] Materia materia)
    {
        if(db.Materias.Any(m => m.Nombre.ToLower() == materia.Nombre.ToLower()))
            {
                ModelState.AddModelError("Nombre", "El nombre de la materia ya existe.");
            }
            if (ModelState.IsValid)
        {
            db.Materias.Add(materia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(materia);
    }

    //Valida el nombre de la materia
    public JsonResult ValidarNombre(string nombre)
    {
        var existe = db.Materias.Any(m => m.Nombre == nombre);
        return Json(!existe, JsonRequestBehavior.AllowGet);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Materia materia = db.Materias.Find(id);
        if (materia == null)
        {
            return HttpNotFound();
        }
        return View(materia);
    }

    // POST: Materias/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "IdentificadorMateria,Nombre,Codigo,NumeroCreditos,NumeroHoras")] Materia materia)
    {
        if (ModelState.IsValid)
        {
            db.Entry(materia).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(materia);
    }

    // GET: Materias/Delete/
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Materia materia = db.Materias.Find(id);
        if (materia == null)
        {
            return HttpNotFound();
        }
        return View(materia);
    }

    // POST: Materias/Delete/
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Materia materia = db.Materias.Find(id);
        db.Materias.Remove(materia);
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