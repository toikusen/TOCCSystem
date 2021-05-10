using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TOCC.Models;

namespace TOCC.Controllers
{
    public class ToccController : Controller
    {
        private TOCCEntities db = new TOCCEntities();

        public ActionResult Home()
        {
            return View();
        }

        // GET: Tocc
        public ActionResult Index()
        {
            return View(db.Visitor.ToList());
        }

        // GET: Tocc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitor.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // GET: Tocc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tocc/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pat_name,MedRec_no,Bed_no,Reserve_date,Id_no,Name,Phone_num,Identity,Travel_history,Occupation,Contact_history,Cluster,Expiry_date,Evaluation_item")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Visitor.Add(visitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitor);
        }

        // GET: Tocc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitor.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Tocc/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pat_name,MedRec_no,Bed_no,Reserve_date,Id_no,Name,Phone_num,Identity,Travel_history,Occupation,Contact_history,Cluster,Expiry_date,Evaluation_item")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitor);
        }

        // GET: Tocc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitor.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Tocc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visitor visitor = db.Visitor.Find(id);
            db.Visitor.Remove(visitor);
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
