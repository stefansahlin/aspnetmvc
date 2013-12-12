using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using efTest2.Models;


namespace efTest2.Controllers
{ 
    public class ContactController : Controller
    {
        IRepository repository;

       // private ContactEntities db = new ContactEntities();
       // Repository repository = new Repository();

        
        public ContactController()
            :this(new Repository())
        {
        }
        
        
        public ContactController(IRepository repository)
        {
            this.repository = repository;
        }
         

      

        public ViewResult Index()
        {
           // var model = this.repository.GetContacts();
            List<Contact> contacts = repository.GetContacts();
            return View(contacts);
           // return View(db.Contacts.ToList());
        }


        public ViewResult Details(int id)
        {
            
            try
            {
                //Contact contact = db.Contacts.Single(c => c.ContactID == id);
                Contact contact = repository.ViewContact(id);
                return View(contact);
            }
            catch (Exception)
            {
                
                return View("NotFound"); 
            }
        }

        
        public ActionResult Create()
        {
            return View();
        } 

        

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                repository.CreateContact(contact);
               // db.Contacts.AddObject(contact);
               // db.SaveChanges();
                //post, redirect, get!!!
                //return direct(actionmetoden success, där det står return view)
                return View("Success"); 
            }

            ViewBag.Message = "Operation failed";
            return View(contact);
          
        }
        
      
        
        public ActionResult Edit(int id)
        {
            try
            {
                Contact contact = repository.ViewContact(id);
                //repository.EditContact(contact);
                //Contact contact = db.Contacts.Single(c => c.ContactID == id);
              
                return View(contact);
            }
            catch (Exception)
            {
                return View("NotFound");
            }
        }

    

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                repository.EditContact(contact);
               // db.Contacts.Attach(contact);
               // db.ObjectStateManager.ChangeObjectState(contact, EntityState.Modified);
               // db.SaveChanges();
                return View("Success");
            
            }
            ViewBag.Message = "Operation failed";
            return View(contact);
        }

        
 
        public ActionResult Delete(int id)
        {
            //Contact contact = db.Contacts.Single(c => c.ContactID == id);
            Contact contact = repository.ViewContact(id);
            return View(contact);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            //Contact contact = db.Contacts.Single(c => c.ContactID == id);
            //db.Contacts.DeleteObject(contact);
            //db.SaveChanges();
            Contact contact = repository.ViewContact(id);
            repository.DeleteContact(contact);
            return View("Success");
            
        }


        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }

    }
}