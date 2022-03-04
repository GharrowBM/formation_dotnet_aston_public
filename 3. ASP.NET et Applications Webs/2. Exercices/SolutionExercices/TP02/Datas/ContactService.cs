using TP02.Models;

namespace TP02.Datas
{
    public class ContactService : IContactService
    {
        private MockDatabase _database;
        private IUploadService _uploadService;

        public ContactService(MockDatabase database, IUploadService uploadService)
        {
            _database = database;
            _uploadService = uploadService;
        }

        public Contact AddContact(Contact contact, IFormFile avatar)
        {
            Avatar newAvatar = new Avatar()
            {
                AvatarPath = _uploadService.Upload(avatar),
                Contact = contact
            };

            contact.Avatar = newAvatar;

            _database.Contacts.Add(contact);

            return contact;
        }

        public bool DeleteContact(int id)
        {
            if (_database.Contacts.Remove(_database.Contacts.Find(contact => contact.Id == id)))
            {
                return true;
            }

            return false;
        }

        public Contact GetContactById(int id)
        {
            return _database.Contacts.FirstOrDefault(contact => contact.Id == id);
        }

        public List<Contact> GetContacts()
        {
            return _database.Contacts.ToList();
        }

        public Contact UpdateContact(int id, Contact newContact, IFormFile avatar)
        {
            Contact contactToEdit = GetContactById(id);

            if (contactToEdit != null)
            {
                contactToEdit.Firstname = newContact.Firstname;
                contactToEdit.Lastname = newContact.Lastname;
                contactToEdit.Email = newContact.Email;
                contactToEdit.Phone = newContact.Phone;

                if (avatar != null)
                {
                    Avatar newAvatar = new Avatar()
                    {
                        AvatarPath = _uploadService.Upload(avatar),
                        Contact = contactToEdit
                    };

                    contactToEdit.Avatar = newAvatar;
                }
                
                return contactToEdit;
            }
            else
            {
                return default(Contact);
            }
        }
    }
}
