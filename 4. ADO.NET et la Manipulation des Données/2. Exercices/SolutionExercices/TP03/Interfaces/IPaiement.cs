using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP03.Interfaces
{
    internal interface IPaiement
    {
        DateTime DatePaiement { get; set; }
        int Id { get; set; }
        bool Payer(decimal montant);
    }
}
