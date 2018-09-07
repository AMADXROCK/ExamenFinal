using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen.Models;

namespace Examen.Controllers
{
    public class AsociadosController : Controller
    {
        private ExamenEntities db = new ExamenEntities();

        // GET: Asociados
        public ActionResult Index()
        {
            var asociados = db.Asociados.Include(a => a.Clientes);
            return View(asociados.ToList());
        }

        // GET: Asociados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asociados asociados = db.Asociados.Find(id);
            if (asociados == null)
            {
                return HttpNotFound();
            }
            return View(asociados);
        }

        // GET: Asociados/Create
        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "RazonSocial");
            return View();
        }

        // POST: Asociados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAsociado,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono,Direccion,Puesto,IDCliente")] Asociados asociados)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Asociados.Add(asociados);
                    db.SaveChanges();
                }
                catch(ExecutionEngineException e)
                {

                }
                
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "RazonSocial", asociados.IDCliente);
            return View(asociados);
        }

        // GET: Asociados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asociados asociados = db.Asociados.Find(id);
            if (asociados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "RazonSocial", asociados.IDCliente);
            return View(asociados);
        }

        // POST: Asociados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAsociado,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono,Direccion,Puesto,IDCliente")] Asociados asociados)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(asociados).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch(ExecutionEngineException e)
                {

                }
                
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "RazonSocial", asociados.IDCliente);
            return View(asociados);
        }

        // GET: Asociados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asociados asociados = db.Asociados.Find(id);
            if (asociados == null)
            {
                return HttpNotFound();
            }
            return View(asociados);
        }

        // POST: Asociados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asociados asociados = db.Asociados.Find(id);
            db.Asociados.Remove(asociados);
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
