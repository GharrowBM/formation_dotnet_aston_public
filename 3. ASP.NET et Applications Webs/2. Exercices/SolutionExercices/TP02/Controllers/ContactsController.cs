using Microsoft.AspNetCore.Mvc;
using TP02.Datas;
using TP02.Models;

namespace TP02.Controllers
{
    public class ContactsController : Controller
    {
        private IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            List<Contact> contacts = _contactService.GetContacts();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Firstname, Lastname, Phone, Email")]Contact contact, IFormFile avatar)
        {

            _contactService.AddContact(contact, avatar);

            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Contact contactDetails = _contactService.GetContactById(id);

            if (contactDetails == null) return View("NotFound");
            return View(contactDetails);
        }

        public IActionResult Edit(int id)
        {
            Contact contactDetails = _contactService.GetContactById(id);

            if (contactDetails == null) return View("NotFound");

            return View(contactDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, Contact newContact, IFormFile avatar)
        {
            Contact contactToEdit = _contactService.GetContactById(id);

            if (contactToEdit == null) return View("NotFound");
            else
            {
                    _contactService.UpdateContact(id, newContact, avatar);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Contact contactToDelete = _contactService.GetContactById(id);

            if (contactToDelete == null) return View("NotFound");

            _contactService.DeleteContact(id);

            return RedirectToAction("Index");
        }
    }
}
