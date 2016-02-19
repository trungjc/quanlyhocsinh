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
    public class GroupUsersController : Controller
    {
        private IEE_Entities db = new IEE_Entities();

        // GET: Admin/GroupUsers
        public ActionResult Index()
        {
            return View(db.AspNetGroupUsers.ToList());
        }

        // GET: Admin/GroupUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetGroupUser aspNetGroupUser = db.AspNetGroupUsers.Find(id);
            if (aspNetGroupUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetGroupUser);
        }

        // GET: Admin/GroupUsers/Create
        public ActionResult Create()
        {
            var aspNetGroupUser = new AspNetGroupUser();
            aspNetGroupUser.IsActive = true;
            return View(aspNetGroupUser);
        }

        // POST: Admin/GroupUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Descriptions,IsActive")] AspNetGroupUser aspNetGroupUser)
        {
            if (ModelState.IsValid)
            {
               
                db.AspNetGroupUsers.Add(aspNetGroupUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspNetGroupUser);
        }

        // GET: Admin/GroupUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetGroupUser aspNetGroupUser = db.AspNetGroupUsers.Find(id);
            if (aspNetGroupUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetGroupUser);
        }

        // POST: Admin/GroupUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Descriptions,IsActive")] AspNetGroupUser aspNetGroupUser)
        {
            if (ModelState.IsValid)
            {
                aspNetGroupUser.IsActive = aspNetGroupUser.IsActive == null ? false : aspNetGroupUser.IsActive;
                db.Entry(aspNetGroupUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetGroupUser);
        }

        // GET: Admin/GroupUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetGroupUser aspNetGroupUser = db.AspNetGroupUsers.Find(id);
            if (aspNetGroupUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetGroupUser);
        }

        // POST: Admin/GroupUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetGroupUser aspNetGroupUser = db.AspNetGroupUsers.Find(id);
            db.AspNetGroupUsers.Remove(aspNetGroupUser);
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
