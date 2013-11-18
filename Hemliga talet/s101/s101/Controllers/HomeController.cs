using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using s101.Models;

namespace s101.Controllers
{
    public class HomeController : Controller
    {
        public SecretNumber sn {get { return Session["SecretNumber"] as SecretNumber; } set { Session["SecretNumber"] = value as SecretNumber; } } 
        public ActionResult Index()
        {            
            sn = new SecretNumber();           
            return View("index", sn);         
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {   
           if (TryUpdateModel(sn))
            {             
                Outcome o = sn.MakeGuess();
                ViewBag.outcome = o;
            }

            return View(sn);
        }
    }
}
