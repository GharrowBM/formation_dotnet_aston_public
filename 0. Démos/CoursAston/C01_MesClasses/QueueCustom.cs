using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public class QueueCustom<Blabla> where Blabla : class
    {
        private Blabla[] _items;
        private int _compteur;

        public Blabla this[int index] { get { return _items[index]; } set { _items[index] = value; } }

        public QueueCustom(int size)
        {
            _items = new Blabla[size];
        }

        public Blabla Add(Blabla element)
        {
            _items[_compteur] = element;

            return _items[_compteur++];
        }
    }
}
