using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5.Classes
{
    internal class Operation
    {
        private int _id;
        private decimal _montant;

        public int Id { get => _id; }
        public decimal Montant { get => _montant; }

        public Operation(int id, decimal montant)
        {
            _id = id;
            _montant = montant;
        }

        public override string ToString()
        {
            return $"{_id}. {Math.Round(_montant, 2)}";
        }
    }
}
