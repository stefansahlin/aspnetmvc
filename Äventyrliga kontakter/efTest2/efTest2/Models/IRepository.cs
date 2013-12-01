using System;
namespace efTest2.Models
{
   public interface IRepository
    {
        void CreateContact(Contact contact);
        void DeleteContact(Contact contact);
        void EditContact(Contact contact);
        System.Collections.Generic.List<Contact> GetContacts();
        Contact ViewContact(int id);
    }
}
