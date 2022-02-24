using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice3.Classes
{
    internal class Pile<T>
    {
        private T[] _elements;
        private int _compteur;

        public Pile(int taille)
        {
            _elements = new T[taille];
            _compteur = 0;
        }

        public T Empiler(T element)
        {
            if (_compteur < _elements.Length)
            {
                _elements[_compteur] = element;
                _compteur++;
                return element;
            }
            else
            {
                Console.WriteLine("La pile est pleine !");
            }

            return default(T);
        }

        public T Depiler()
        {
            if (_compteur > 0)
            {
                T elementDepile = _elements[_compteur -1];
                _elements[_compteur-1] = default(T);
                _compteur--;
                return elementDepile;
            }

            return default(T);
        }

        public T RecupererA(int index)
        {
            if (index >= 0 && index <= _compteur) return _elements[index];
            return default(T);
        }
    }
}
