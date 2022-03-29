using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03_Classes
{
    public class LePendu
    {
        private int _nbEssai;
        private string _masque;
        private string _motAtrouve;

        public int NbEssai { get => _nbEssai; }
        public string Masque { get => _masque; }
        public string MotAtrouve { get => _motAtrouve; }

        public LePendu()
        {
            _nbEssai = 10;
        }

        public bool TestChar(char c)
        {
            string tmpMasque = "";
            bool test = false;
            for (int i = 0; i < MotAtrouve.Length; i++)
            {
                if (MotAtrouve[i] == c)
                {
                    tmpMasque += c;
                    test = true;
                }
                else
                {
                    tmpMasque += _masque[i];

                }
            }

            if (!test) _nbEssai--;

            _masque = tmpMasque;

            return test;
        }

        public bool TestWin()
        {
            return NbEssai > 0 && Masque == MotAtrouve;
        }

        public void GenererMasque(IGenerateur generateurDeMot)
        {
            _motAtrouve = generateurDeMot.Generer();
            _masque = "";
            foreach (char c in MotAtrouve)
            {
                _masque += "*";
            }
        }
    }
}
