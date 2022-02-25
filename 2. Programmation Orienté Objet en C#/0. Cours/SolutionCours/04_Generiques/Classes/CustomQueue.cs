using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Generiques.Classes
{
    internal class CustomQueue<Blabla> where Blabla : class 
    {
        private Blabla[] _items;

        public Blabla this[int index] { get { return _items[index]; }set { _items[index] = value; } }

        public CustomQueue(int size)
        {
            _items = new Blabla[size];
        }

        public Blabla[] GetAll()
        {
            return _items;
        }

        public Blabla GetById(int index)
        {
            return _items[index];
        }

        public Blabla Add(Blabla newItem)
        {
            if (_items[_items.Length - 1] is not default(Blabla)) return default(Blabla);

            for(int i = _items.Length - 1; i >= 1; i--)
            {
                if (_items[i - 1] is not default(Blabla)) _items[i] = _items[i - 1];
            }

            _items[0] = newItem;

            return newItem;
        }

        public Blabla Remove()
        {
            if (_items[0] is default(Blabla)) return default(Blabla);

            for(int i = _items.Length - 1; i >= 0; i--)
            {
                if (_items[i] is not default(Blabla))
                {
                    Blabla itemGot = _items[i];
                    _items[i] = default(Blabla);
                    return itemGot;
                }
            }

            return default(Blabla);
        }
    }
}
