using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice09.Classes
{
    internal class CollectionAlphabet<T>
    {
        private T[] _tableau;

        public T[] Tableau { get { return _tableau; } }

        public CollectionAlphabet()
        {
            _tableau = new T[26];
        }

        public T this[char lettre]
        {
            get { return _tableau[(int) lettre - 97]; }
            set { _tableau[(int)lettre - 97] = value; }
        }
    }
}
