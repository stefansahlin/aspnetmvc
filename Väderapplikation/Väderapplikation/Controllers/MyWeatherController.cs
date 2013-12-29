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
    public class MyWeatherController : Controller
    {
        private ss222enProjectEntities1 db = new ss222enProjectEntities1();

        //
        // GET: /MyWeather/

        public ActionResult Index() //myWeather ska komma in som valfri parameter
        {
            //Om myWeather finns...
            //myWeather.projectuser = request.username //eller nåt...
           // db.MyWeathers.Add(myweather);
           // db.SaveChanges();
            //Annars går du direkt hit
            var username = User.Identity.Name;
            
            
            var userlist = (from w in db.MyWeathers where w.projectuser == username select w).ToList();
            return View(userlist);
           // return View(db.MyWeathers.ToList()); //Hämtar alla sparade väder, även hämtade av andra medlemmar.
        }

        //
        // GET: /MyWeather/Details/5

        public ActionResult Details(int id = 0)
        {
            var placeService = new PlaceService2();
            MyWeather myweather = db.MyWeathers.Find(id);
            string place = myweather.place;
            string region = placeService.GetRegion(place);
            
            ExtWeather extWeather = placeService.GetWeatherInfo(place, region);
            myweather.latitude = extWeather.latitude;
            myweather.longitude = extWeather.longitude;
            myweather.day1day = extWeather.Day1day;
            myweather.day2day = extWeather.Day2day;
            myweather.day3day = extWeather.Day3day;
            myweather.day4day = extWeather.Day4day;
            myweather.day5day = extWeather.Day5day;
           // @Viewbag.day1temp = weatherInfo.day1temp;
            // var place = myweather.place; //Bör även hämta med longitud och latitud också...och eventuellt även region...
            if (myweather == null)
            {
                return HttpNotFound();
            }
            ViewBag.latitude = extWeather.latitude;
            ViewBag.longitude = extWeather.longitude;
            ViewBag.day1Weather = extWeather.Day1Weather;
            ViewBag.day2Weather = extWeather.Day2Weather;
            ViewBag.day3Weather = extWeather.Day3Weather;
            ViewBag.day4Weather = extWeather.Day4Weather;
            ViewBag.day5Weather = extWeather.Day5Weather;
            ViewBag.day1temp = extWeather.Day1temp;
            ViewBag.day2temp = extWeather.Day2temp;
            ViewBag.day3temp = extWeather.Day3temp;
            ViewBag.day4temp = extWeather.Day4temp;
            ViewBag.day5temp = extWeather.Day5temp;

           /* ViewBag.day1temp = extWeather.Day1temp;
            ViewBag.day2temp = extWeather.Day2temp;
            ViewBag.day3temp = extWeather.Day3temp;
            ViewBag.day4temp = extWeather.Day4temp;
            ViewBag.day5temp = extWeather.Day5temp;*/
            //Skicka med användarnamn, coordinater och uppgifter här...//Går förmodligen att skicka med hela objektet, gör dock först om
            //processen på samma sätt som du gjorde med placeInput och det där...
            return View(myweather);
        }

        //
        // GET: /MyWeather/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MyWeather/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        //GetInput ska läggas här istället för i placeInput, här ska jag sedan spara och därefter redirecta till index.
        public ActionResult Create(MyWeather myweather)
        {
            
            var placeService = new PlaceService();
            var username = User.Identity.Name;
            var place = myweather.place;
            var region = placeService.GetRegion(place);
            var coordinates = placeService.GetCoordinates(place);
            var latitude = coordinates[1];
            var longitude = coordinates[0];
           // myweather.projectuser = username;
            //myweather.latitude = latitude;
            myweather.longitude = decimal.Parse(coordinates[0], System.Globalization.CultureInfo.InvariantCulture);
            myweather.latitude = decimal.Parse(coordinates[1], System.Globalization.CultureInfo.InvariantCulture);
            myweather.projectuser = username;
             

            if (ModelState.IsValid)
            {
                //En javascriptfunktion som frågar om man vill spara platsen.
                db.MyWeathers.Add(myweather);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(myweather);
        }

        //
        // GET: /MyWeather/Edit/5
        //Den här ska tas bort...
        public ActionResult Edit(int id = 0)
        {
            MyWeather myweather = db.MyWeathers.Find(id);
            if (myweather == null)
            {
                return HttpNotFound();
            }
            return View(myweather);
        }

        //
        // POST: /MyWeather/Edit/5
        //Den här ska tas bort...
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MyWeather myweather)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myweather).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myweather);
        }

        //
        // GET: /MyWeather/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MyWeather myweather = db.MyWeathers.Find(id);
            if (myweather == null)
            {
                return HttpNotFound();
            }
            return View(myweather);
        }

        //
        // POST: /MyWeather/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyWeather myweather = db.MyWeathers.Find(id);
            db.MyWeathers.Remove(myweather);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



        public ActionResult GetWeather()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWeather([Bind(Include = "Place")]ViewModel model)
        {
            //Eventuellt skapar du här bara ett meddelande som säger att platsen har hittats eller som talar om att den inte har det.
            //Sedan sparar du den, hämtar eventuellt coordinater och redirectar till index...
            return View();
        }

       
        
    }
}