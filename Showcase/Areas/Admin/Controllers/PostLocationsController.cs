﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Showcase.DataContexts;
using Showcase.Models;

namespace Showcase.Areas.Admin.Controllers
{
    public class PostLocationsController : Controller
    {
        private BlogDb db = new BlogDb();

        // GET: Admin/PostLocations
        public ActionResult Index()
        {
            return View(db.PostLocations.ToList());
        }

        // GET: Admin/PostLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostLocation postLocation = db.PostLocations.Find(id);
            if (postLocation == null)
            {
                return HttpNotFound();
            }
            return View(postLocation);
        }

        // GET: Admin/PostLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PostLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostLocationId,Created,LastModified,PostLocationName")] PostLocation postLocation)
        {
            if (ModelState.IsValid)
            {
                db.PostLocations.Add(postLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postLocation);
        }

        // GET: Admin/PostLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostLocation postLocation = db.PostLocations.Find(id);
            if (postLocation == null)
            {
                return HttpNotFound();
            }
            return View(postLocation);
        }

        // POST: Admin/PostLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostLocationId,Created,LastModified,PostLocationName")] PostLocation postLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postLocation);
        }

        // GET: Admin/PostLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostLocation postLocation = db.PostLocations.Find(id);
            if (postLocation == null)
            {
                return HttpNotFound();
            }
            return View(postLocation);
        }

        // POST: Admin/PostLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostLocation postLocation = db.PostLocations.Find(id);
            db.PostLocations.Remove(postLocation);
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