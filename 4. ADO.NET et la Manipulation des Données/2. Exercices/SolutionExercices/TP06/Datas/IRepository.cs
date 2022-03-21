using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06.Datas
{
    internal interface IRepository<T> where T : class
    {
        public T Add(T entity);
        public T Get(int id);
        public List<T> GetAll();
        public T Update(int id, T entity);
        public bool Delete(int id);
        public T AddOrUpdate(T entity);
    }
}
