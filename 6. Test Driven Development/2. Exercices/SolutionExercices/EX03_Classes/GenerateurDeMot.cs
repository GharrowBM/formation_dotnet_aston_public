using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03_Classes
{
    public interface IGenerateur
    {
        public string Generer();
    }
    public class GenerateurDeMot : IGenerateur
    {

        private Random _random = new Random();
        private string[] _mots = new string[] { "google", "apple", "microsoft", "amazon", "facebook" };

        public string Generer()
        {
            return _mots[_random.Next(_mots.Length)];
        }
    }
}
