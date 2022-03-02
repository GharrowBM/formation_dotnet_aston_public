using Microsoft.AspNetCore.Mvc;
using TP01.Models;
using TP01.Datas;

namespace TP01.Controllers
{
    public class TodosController : Controller
    {
        private FakeDB _fakeDB;

        public TodosController(FakeDB fakeDB)
        {
            _fakeDB = fakeDB;
        }

        public IActionResult Index()
        {
            List<TodoItem> list = _fakeDB.Todos.ToList();

            return View(list);
        }

        [HttpPost]
        public IActionResult AddNewTodo(string title, string description)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description))
            {
                _fakeDB.Todos.Add(new TodoItem(title, description));
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTodo(int id)
        {
            TodoItem item = _fakeDB.Todos.Find(todo => todo.Id == id);

            if (item != null)
            {
                _fakeDB.Todos.Remove(item);
            }

            return RedirectToAction("Index");
        }
    }
}
