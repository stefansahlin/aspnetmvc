using System;
namespace efTest2.Models
{
   public interface IRepository : IDisposable
    {
        void CreateContact(Contact contact);
        void DeleteContact(Contact contact);
        void EditContact(Contact contact);
        System.Collections.Generic.List<Contact> GetContacts();
        //System.Collections.Generic.List<Contact> GetLastContacts();
        Contact ViewContact(int id);
    }

    //next birthday 3 crud, i kursmaterialrep
}
