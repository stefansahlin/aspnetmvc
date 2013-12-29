using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Väderapplikation.Models;

namespace Väderapplikation.Controllers
{
    public class NewWeatherController : Controller
    {
        private ss222enProjectEntities db = new ss222enProjectEntities();

        //
        // GET: /NewWeather/

        public ActionResult Index()
        {
            var newweathers = db.NewWeathers.Include(n => n.NewUser);
            return View(newweathers.ToList());
        }

        //
        // GET: /NewWeather/Details/5

        public ActionResult Details(int id = 0)
        {
            NewWeather newweather = db.NewWeathers.Find(id);
            if (newweather == null)
            {
                return HttpNotFound();
            }
            return View(newweather);
        }

        //
        // GET: /NewWeather/Create

        public ActionResult Create()
        {
            ViewBag.owner = new SelectList(db.NewUsers, "ID", "name");
            return View();
        }

        //
        // POST: /NewWeather/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewWeather newweather)
        {
            if (ModelState.IsValid)
            {
                db.NewWeathers.Add(newweather);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.owner = new SelectList(db.NewUsers, "ID", "name", newweather.owner);
            return View(newweather);
        }

        //
        // GET: /NewWeather/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NewWeather newweather = db.NewWeathers.Find(id);
            if (newweather == null)
            {
                return HttpNotFound();
            }
            ViewBag.owner = new SelectList(db.NewUsers, "ID", "name", newweather.owner);
            return View(newweather);
        }

        //
        // POST: /NewWeather/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewWeather newweather)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newweather).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.owner = new SelectList(db.NewUsers, "ID", "name", newweather.owner);
            return View(newweather);
        }

        //
        // GET: /NewWeather/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NewWeather newweather = db.NewWeathers.Find(id);
            if (newweather == null)
            {
                return HttpNotFound();
            }
            return View(newweather);
        }

        //
        // POST: /NewWeather/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewWeather newweather = db.NewWeathers.Find(id);
            db.NewWeathers.Remove(newweather);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}