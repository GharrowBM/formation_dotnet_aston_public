using TP02.Models;

namespace TP02.Datas
{
    public interface IContactService
    {
        public Contact AddContact(Contact contact, IFormFile avatar);
        public Contact GetContactById(int id);
        public List<Contact> GetContacts();
        public Contact UpdateContact(int id, Contact newContact, IFormFile avatar);
        public bool DeleteContact(int id);
    }
}
