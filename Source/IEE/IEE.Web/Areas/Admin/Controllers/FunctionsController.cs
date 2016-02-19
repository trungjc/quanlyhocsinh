using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IEE.Lib.Models;

namespace IEE.Web.Areas.Admin.Controllers
{
    public class FunctionsController : Controller
    {
        private IEE_Entities db = new IEE_Entities();

        // GET: Admin/Functions
        public ActionResult Index()
        {
            return View(db.SysFunctions.ToList());
        }

        // GET: Admin/Functions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysFunction sysFunction = db.SysFunctions.Find(id);
            if (sysFunction == null)
            {
                return HttpNotFound();
            }
            return View(sysFunction);
        }

        // GET: Admin/Functions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Functions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Controllers,Actions,Description,IsActive")] SysFunction sysFunction)
        {
            if (ModelState.IsValid)
            {
                db.SysFunctions.Add(sysFunction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sysFunction);
        }

        // GET: Admin/Functions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysFunction sysFunction = db.SysFunctions.Find(id);
            if (sysFunction == null)
            {
                return HttpNotFound();
            }
            return View(sysFunction);
        }

        // POST: Admin/Functions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Controllers,Actions,Description,IsActive")] SysFunction sysFunction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysFunction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysFunction);
        }

        // GET: Admin/Functions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysFunction sysFunction = db.SysFunctions.Find(id);
            if (sysFunction == null)
            {
                return HttpNotFound();
            }
            return View(sysFunction);
        }

        // POST: Admin/Functions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysFunction sysFunction = db.SysFunctions.Find(id);
            db.SysFunctions.Remove(sysFunction);
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
