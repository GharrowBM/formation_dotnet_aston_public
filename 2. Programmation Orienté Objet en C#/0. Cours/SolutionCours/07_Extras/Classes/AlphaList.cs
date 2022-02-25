using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Extras.Classes
{
    internal class AlphaList
    {
        public string[] _items { get; private set; }

        /*
         * L'indexeur est défini par le mot clé THIS suivi d'une notation en crochets, précédé du type renvoyé 
         * et suivi d'un setter et d'un getter pouvant posséder une logique métier
         * 
         * Ici l'indexeur renvoie simplement l'élement du tableau qu'il possède, ce qui permet une notation plus rapide que AlphaList.Items[i] par exemple
         * 
         */

        public string this[int index] { get => _items[index]; set => _items[index] = value; }

        public int Count => _items.Length;

        public AlphaList(params string[] strings)
        {
            _items = new string[strings.Length];

            strings.CopyTo(_items, 0);
        }

    }
}
