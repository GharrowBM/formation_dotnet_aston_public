namespace C05_EFCore.Datas
{
    public interface IRepository<T> where T : class
    {
        public T Add(T entity);
        public T Update(T entity);
        public T AddOrUpdate(T entity);
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public bool Delete(int id);
    }
}
