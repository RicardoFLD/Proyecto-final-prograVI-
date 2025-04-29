using proyecto_final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_final.Controllers
{
    public class AlumnosController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Alumnos
        public ActionResult Index()
        {
            var alumnos = db.Alumnos
                            .Include(a => a.Provincia)
                            .Include(a => a.Canton)
                            .Include(a => a.Distrito)
                            .ToList();
            return View(alumnos);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        public ActionResult Create()
        {
            ViewBag.Provincias = new SelectList(db.Provincias, "IdentificadorProvincia", "Nombre");
            ViewBag.Cantones = new SelectList(db.Cantones, "IdentificadorCanton", "Nombre");
            ViewBag.Distritos = new SelectList(db.Distritos, "IdentificadorDistrito", "Nombre");

            ViewBag.Generos = new SelectList(new[]
{
            new { Value = 'M', Text = "Masculino" },
            new { Value = 'F', Text = "Femenino" }
            }, "Value", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                    db.Alumnos.Add(alumno);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            ViewBag.Provincias = new SelectList(db.Provincias, "IdentificadorProvincia", "Nombre", alumno.IdentificadorProvincia);
            ViewBag.Cantones = new SelectList(db.Cantones, "IdentificadorCanton", "Nombre", alumno.IdentificadorCanton);
            ViewBag.Distritos = new SelectList(db.Distritos, "IdentificadorDistrito", "Nombre", alumno.IdentificadorDistrito);
            ViewBag.Generos = new SelectList(new[]
            {
                new { Value = 'M', Text = "Masculino" },
                new { Value = 'F', Text = "Femenino" }
            }, "Value", "Text", alumno.Genero);
            return View(alumno);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.Provincias = new SelectList(db.Provincias, "IdentificadorProvincia", "Nombre", alumno.IdentificadorProvincia);
            ViewBag.Cantones = new SelectList(db.Cantones, "IdentificadorCanton", "Nombre", alumno.IdentificadorCanton);
            ViewBag.Distritos = new SelectList(db.Distritos, "IdentificadorDistrito", "Nombre", alumno.IdentificadorDistrito);

            ViewBag.Generos = new SelectList(new[]
{
            new { Value = 'M', Text = "Masculino" },
            new { Value = 'F', Text = "Femenino" }
            }, "Value", "Text");
            return View(alumno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Provincias = new SelectList(db.Provincias, "IdentificadorProvincia", "Nombre", alumno.IdentificadorProvincia);
            ViewBag.Cantones = new SelectList(db.Cantones, "IdentificadorCanton", "Nombre", alumno.IdentificadorCanton);
            ViewBag.Distritos = new SelectList(db.Distritos, "IdentificadorDistrito", "Nombre", alumno.IdentificadorDistrito);
            ViewBag.Generos = new SelectList(new[]
 {
                new { Value = 'M', Text = "Masculino" },
                new { Value = 'F', Text = "Femenino" }
            }, "Value", "Text", alumno.Genero);
            return View(alumno);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno alumno = db.Alumnos.Find(id);
            db.Alumnos.Remove(alumno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}