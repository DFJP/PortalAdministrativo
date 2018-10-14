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
    public class PermisosXRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PermisosXRoles
        public ActionResult Index()
        {
            var permisosXRoles = db.PermisosXRoles.Include(p => p.Permiso).Include(p => p.Rol);
            return View(permisosXRoles.ToList());
        }

        // GET: PermisosXRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermisosXRoles permisosXRoles = db.PermisosXRoles.Find(id);
            if (permisosXRoles == null)
            {
                return HttpNotFound();
            }
            return View(permisosXRoles);
        }

        // GET: PermisosXRoles/Create
        public ActionResult Create()
        {
            var permisos = db.Permisos.SqlQuery("SELECT * FROM dbo.Permisoes WHERE Activo=1").ToList();
            var roles = db.Rols.SqlQuery("SELECT * FROM dbo.Rols WHERE Activo=1").ToList();
            ViewBag.IdPermiso = new SelectList(permisos, "Id", "PermisoName");
            ViewBag.IdRol = new SelectList(roles, "Id", "RolName");
            return View();
        }

        // POST: PermisosXRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdRol,IdPermiso")] PermisosXRoles permisosXRoles)
        {
            if (ModelState.IsValid)
            {
                db.PermisosXRoles.Add(permisosXRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPermiso = new SelectList(db.Permisos, "Id", "PermisoName", permisosXRoles.IdPermiso);
            ViewBag.IdRol = new SelectList(db.Rols, "Id", "RolName", permisosXRoles.IdRol);
            return View(permisosXRoles);
        }

        // GET: PermisosXRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermisosXRoles permisosXRoles = db.PermisosXRoles.Find(id);
            if (permisosXRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPermiso = new SelectList(db.Permisos, "Id", "PermisoName", permisosXRoles.IdPermiso);
            ViewBag.IdRol = new SelectList(db.Rols, "Id", "RolName", permisosXRoles.IdRol);
            return View(permisosXRoles);
        }

        // POST: PermisosXRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdRol,IdPermiso")] PermisosXRoles permisosXRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permisosXRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPermiso = new SelectList(db.Permisos, "Id", "PermisoName", permisosXRoles.IdPermiso);
            ViewBag.IdRol = new SelectList(db.Rols, "Id", "RolName", permisosXRoles.IdRol);
            return View(permisosXRoles);
        }

        // GET: PermisosXRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermisosXRoles permisosXRoles = db.PermisosXRoles.Find(id);
            if (permisosXRoles == null)
            {
                return HttpNotFound();
            }
            return View(permisosXRoles);
        }

        // POST: PermisosXRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PermisosXRoles permisosXRoles = db.PermisosXRoles.Find(id);
            db.PermisosXRoles.Remove(permisosXRoles);
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
