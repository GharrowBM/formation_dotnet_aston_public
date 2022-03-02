using TP01.Models;

namespace TP01.Datas
{
    public class FakeDB
    {
        public List<TodoItem> Todos { get; set; }

        public FakeDB()
        {
            Todos = new List<TodoItem>();
        }

    }
}
