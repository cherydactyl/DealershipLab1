using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DealershipLab1.Models;

namespace DealershipLab1.Controllers
{
    public class AutoModelsController : Controller
    {
        private AutoDBContext db = new AutoDBContext();

        //// GET: AutoModels
        //public ActionResult Index()
        //{
        //    return View(db.AutoModel.ToList());
        //}
        public ActionResult Index(string searchString)
        {
            var movies = from m in db.AutoModel
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Model.Contains(searchString));
            }

            return View(movies);
        }

        // GET: AutoModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoModel autoModel = db.AutoModel.Find(id);
            if (autoModel == null)
            {
                return HttpNotFound();
            }
            return View(autoModel);
        }

        // GET: AutoModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Make,Model,year,MPG,color,MSRP")] AutoModel autoModel)
        {
            if (ModelState.IsValid)
            {
                db.AutoModel.Add(autoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autoModel);
        }

        // GET: AutoModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoModel autoModel = db.AutoModel.Find(id);
            if (autoModel == null)
            {
                return HttpNotFound();
            }
            return View(autoModel);
        }

        // POST: AutoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Make,Model,year,MPG,color,MSRP")] AutoModel autoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autoModel);
        }

        // GET: AutoModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoModel autoModel = db.AutoModel.Find(id);
            if (autoModel == null)
            {
                return HttpNotFound();
            }
            return View(autoModel);
        }

        // POST: AutoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoModel autoModel = db.AutoModel.Find(id);
            db.AutoModel.Remove(autoModel);
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
