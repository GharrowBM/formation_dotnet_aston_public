namespace C02_ASPNet.Controllers.Services
{
    public class DabaseMock
    {
        private List<string> _list;
        public List<string> List { get { return _list; } }
        public DabaseMock()
        {
            _list = new List<string>();

            SeedDb();
        }

        public bool Add(string addedValue)
        {
            _list.Add(addedValue);

            return true;
        }

        public bool Remove(int id)
        {
            _list.RemoveAt(id);

            return true;
        }

        public bool Edit(int id, string newValue)
        {
            _list[id] = newValue;

            return true;
        }

        public List<string> GetAll()
        {
            return _list;
        }

        private void SeedDb()
        {
            if (!_list.Any())
            {
                _list.Add("Bernie");
                _list.Add("Arnold");
                _list.Add("Chloée");
                _list.Add("John");
            }
        }
    }
}
