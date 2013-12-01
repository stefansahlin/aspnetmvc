using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using efTest2.Models;
namespace efTest2.Models
    //föreläsning 121119 för repository
{
    public class Repository : IRepository //: efTest2.Models.IRepository
    {
        private ContactEntities db = new ContactEntities();

        public Contact ViewContact(int id)
        {
            Contact contact = db.Contacts.Single(c => c.ContactID == id);
            return contact;
        }

        public List<Contact> GetContacts()
        {
            List<Contact> contacts = db.Contacts.ToList();
            return contacts;
        }

        public void CreateContact(Contact contact)
        {
            db.Contacts.AddObject(contact);
            db.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            db.Contacts.DeleteObject(contact);
            db.SaveChanges();
        }

        public void EditContact(Contact contact)
        {
            db.Contacts.Attach(contact);
            db.ObjectStateManager.ChangeObjectState(contact, EntityState.Modified); //Seems to work without this code
            db.SaveChanges();
        }

        /*
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
         * */
    }
}