using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06.Classes
{
    internal static class ExtensionsListe
    {
        public static T Rechercher<T>(this List<T> source, Func<T, bool> predicate)
        {
            T itemToFind = default(T);

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    itemToFind = item;
                    break;
                }
            }

            return itemToFind;
        }
    }
}
