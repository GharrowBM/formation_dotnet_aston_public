using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public class QueueCustom<Blabla> : IEnumerator, IEnumerable where Blabla : class
    {
        private Blabla[] _items;
        private int _compteur;

        public Blabla this[int index] { get { return _items[index]; } }

        public QueueCustom(int size)
        {
            _items = new Blabla[size];
        }

        public object Current => _items[_compteur];

        public Blabla Add(Blabla element)
        {
            _items[_compteur] = element;

            return _items[_compteur++];
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public bool MoveNext()
        {
            _compteur++;
            return (_compteur < _items.Length);
        }

        public void Reset()
        {
            _compteur = 0;
        }
    }
}
