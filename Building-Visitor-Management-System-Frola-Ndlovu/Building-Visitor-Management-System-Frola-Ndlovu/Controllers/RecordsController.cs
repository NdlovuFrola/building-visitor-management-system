using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Building_Visitor_Management_System_Frola_Ndlovu.Models;

namespace Building_Visitor_Management_System_Frola_Ndlovu.Controllers
{
    public class RecordsController : Controller
    {
        private readonly Entities3 db = new Entities3();

        // GET: Records
        public ActionResult Index()
        {
            var records = db.Records.Include(r => r.Tenant).Include(r => r.Visitor);
            return View(records.ToList());
        }

        // GET: Records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            ViewBag.TenantID = new SelectList(db.Tenants, "Id", "Fullname");
            ViewBag.VisitorID = new SelectList(db.Visitors, "ID", "Fullname");
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Time,VisitorID,TenantID")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenantID = new SelectList(db.Tenants, "Id", "Fullname", record.TenantID);
            ViewBag.VisitorID = new SelectList(db.Visitors, "ID", "Fullname", record.VisitorID);
            return View(record);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenantID = new SelectList(db.Tenants, "Id", "Fullname", record.TenantID);
            ViewBag.VisitorID = new SelectList(db.Visitors, "ID", "Fullname", record.VisitorID);
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Time,VisitorID,TenantID")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenantID = new SelectList(db.Tenants, "Id", "Fullname", record.TenantID);
            ViewBag.VisitorID = new SelectList(db.Visitors, "ID", "Fullname", record.VisitorID);
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
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
