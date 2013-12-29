using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Väderapplikation.Models;

namespace Väderapplikation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string username)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
           // ViewBag.Username = username;
            string name = User.Identity.Name;
            ViewBag.Username = name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PlaceInput()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlaceInput([Bind(Include = "Place")]ViewModel model)
        {
            /*
             * Put in a try catch here, and then send 
             * */
            if (ModelState.IsValid)
            {
                
                var place = model.place;
                var time = DateTime.Now;
                var placeService = new PlaceService();
                string region = placeService.GetRegion(place);
                
                NewWeather weatherIno = placeService.GetWeatherinfo(place, region);

            
                TempData["weatherObject"] = weatherIno;
                TempData["latitude"] = weatherIno.latitude;
                TempData["longitude"] = weatherIno.longitude;

                var placeService2 = new PlaceService2();
                ExtWeather extWeather = placeService2.GetWeatherInfo(place, region);
                TempData["Test"] = extWeather.Day1Weather;
                TempData["Day2Weather"] = extWeather.Day2Weather;
                TempData["Day3Weather"] = extWeather.Day3Weather;
                TempData["Day4Weather"] = extWeather.Day4Weather;
                TempData["Day5Weather"] = extWeather.Day5Weather;
                
                return RedirectToAction("GetMap");
            }
            return View();
        }

        public ActionResult GetMap()
        {
            var weather = TempData["weatherObject"];
            var latitude = TempData["latitude"];
            var longitude = TempData["longitude"];
            var firstday = TempData["Test"];
            var day2Weather = TempData["Day2Weather"];
            var day3Weather = TempData["Day3Weather"];
            var day4Weather = TempData["Day4Weather"];
            var day5Weather = TempData["Day5Weather"];
            // Koordinaterna bör komma in i actionresult och skickas vidare in i View(). Alternativt som objekt.
            //Objektet ska sparas i databasen. Antagligen behöver det här göras redan innan den lämnar newWeatherController och kommer hit
            //Objektet kommer att göras om till ett newWeather och vyn kommer sedan bli starkt typad och skicka in det objektet till vyn
            //Prova med viewbag så länge.
            ViewBag.Object = weather;
            ViewBag.longitude = longitude;
            ViewBag.latitude = latitude;
            ViewBag.test = firstday;

            ViewBag.day2Weather = day2Weather;
            ViewBag.day3Weather = day3Weather;
            ViewBag.day4Weather = day4Weather;
            ViewBag.day5Weather = day5Weather;

            return View(weather);
        }

        public ActionResult GetNewWeatherMap()
        {
            var weather = TempData["weatherObject"];
            var latitude = TempData["latitude"];

            // Koordinaterna bör komma in i actionresult och skickas vidare in i View(). Alternativt som objekt.
            //Objektet ska sparas i databasen. Antagligen behöver det här göras redan innan den lämnar newWeatherController och kommer hit
            //Objektet kommer att göras om till ett newWeather och vyn kommer sedan bli starkt typad och skicka in det objektet till vyn
            //Prova med viewbag så länge.
            ViewBag.latitude = latitude;
            return View(weather);
        }
    }
}
