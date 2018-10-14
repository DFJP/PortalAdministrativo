using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portal.Models;

namespace Portal.Controllers
{
    public class RolesXUsuarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RolesXUsuario
        public ActionResult Index()
        {
            var rolsXUsuario = db.RolsXUsuario.Include(r => r.Rol).Include(r => r.Usuario);
            return View(rolsXUsuario.ToList());
        }

        // GET: RolesXUsuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesXUsuario rolesXUsuario = db.RolsXUsuario.Find(id);
            if (rolesXUsuario == null)
            {
                return HttpNotFound();
            }
            return View(rolesXUsuario);
        }

        // GET: RolesXUsuario/Create
        public ActionResult Create()
        {
            var roles = db.Rols.SqlQuery("SELECT * FROM dbo.Rols WHERE Activo=1").ToList();
            ViewBag.IdRol = new SelectList(roles, "Id", "RolName");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Apellidos");
            return View();
        }

        // POST: RolesXUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUsuario,IdRol")] RolesXUsuario rolesXUsuario)
        {
            if (ModelState.IsValid)
            {
                db.RolsXUsuario.Add(rolesXUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRol = new SelectList(db.Rols, "Id", "RolName", rolesXUsuario.IdRol);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Apellidos", rolesXUsuario.IdUsuario);
            return View(rolesXUsuario);
        }

        // GET: RolesXUsuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesXUsuario rolesXUsuario = db.RolsXUsuario.Find(id);
            if (rolesXUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRol = new SelectList(db.Rols, "Id", "RolName", rolesXUsuario.IdRol);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Apellidos", rolesXUsuario.IdUsuario);
            return View(rolesXUsuario);
        }

        // POST: RolesXUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUsuario,IdRol")] RolesXUsuario rolesXUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolesXUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRol = new SelectList(db.Rols, "Id", "RolName", rolesXUsuario.IdRol);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Apellidos", rolesXUsuario.IdUsuario);
            return View(rolesXUsuario);
        }

        // GET: RolesXUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesXUsuario rolesXUsuario = db.RolsXUsuario.Find(id);
            if (rolesXUsuario == null)
            {
                return HttpNotFound();
            }
            return View(rolesXUsuario);
        }

        // POST: RolesXUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RolesXUsuario rolesXUsuario = db.RolsXUsuario.Find(id);
            db.RolsXUsuario.Remove(rolesXUsuario);
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
