using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using efTest2.Models;
//System.contentModel might be necessary for the data annotations

namespace efTest2.Controllers
{ 
    public class ContactController : Controller
    {
        private ContactEntities db = new ContactEntities();

        //
        // GET: /Contact/

        public ViewResult Index()
        {
            return View(db.Contacts.ToList());
        }

        //
        // GET: /Contact/Details/5

        public ViewResult Details(int id)
        {
            //Ta reda på om resultatet som kommer ut är null. Om ja, gå vidare, om nej, skicka in error page.
            //Gör eventuellt även en try / catch som fångar upp fel som inte är förväntade som som skickar vidare till en felsida.


            //This one is now working
            try
            {
                Contact contact = db.Contacts.Single(c => c.ContactID == id);
                // if (contact == null){return view not found} //Borde fungera
                return View(contact);
            }
            catch (Exception)
            {
                //ModelState.AddModelError(String.Empty, "Ett fel inträffade");
                return View("NotFound"); ////Fungerar, gör nu samma sak på de andra actionåtgrärderna.
            }
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.AddObject(contact);
                db.SaveChanges();
                return View("Success"); //Fungerar, gör nu samma sak på de andra actionåtgrärderna.
               // return RedirectToAction("Index");  //working
            }

            return View(contact);
            //Gå istället vidare till en vy som talar om att operationen lyckades eller skriv ut det i en sträng.
        }
        
        //
        // GET: /Contact/Edit/5
 
        public ActionResult Edit(int id)
        {
            Contact contact = db.Contacts.Single(c => c.ContactID == id);
          /*  if (contact == null)
            {
                return View("NotFound");
            }*/
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Attach(contact);
                db.ObjectStateManager.ChangeObjectState(contact, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5
 
        public ActionResult Delete(int id)
        {
            Contact contact = db.Contacts.Single(c => c.ContactID == id);
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Contact contact = db.Contacts.Single(c => c.ContactID == id);
            db.Contacts.DeleteObject(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //Check if pages are valid, and if not, send person to error page.
    }
}