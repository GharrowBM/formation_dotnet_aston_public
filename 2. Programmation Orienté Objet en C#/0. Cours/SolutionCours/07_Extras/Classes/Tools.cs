using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Extras.Classes
{

    /*
     * Pour réaliser une extension de méthode, la classe possédant cette extension doit être statique
     * 
     */

    internal static class Tools
    {
        /*
         * De plus, la méthode en elle même doit être statique.
         * 
         * Le lien avec la classe que l'on cherche à etendre vient de l'utilisation du mot-clé THIS dans le premier paramètre de cette méthode, qui permet de cibler ce dernier
         * 
         */

        public static string ToCapitalize(this string baseString)
        {
            return baseString.Substring(0,1).ToUpper() + baseString.Substring(1, baseString.Length - 1).ToLower();
        }

    }
}
