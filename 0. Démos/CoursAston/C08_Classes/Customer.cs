using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08_Classes
{

    /*
     * La création d'une interface dans le but de réaliser un Mock d'une classe est possible mais il s'agit d'une mauvaise pratique. 
     * L'interface ci-dessous vise à montrer la faisabilité de ce processus, et non à en montrer l'intérêt ou l'importance
     * 
     */

    public interface ICustomer
    {
        public int Discount { get; set; }
        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }

        public string CombineNames(string firstName, string lastName);
        public CustomerType GetCustomerDetails();
    }
    public class Customer : ICustomer // Il n'y a pas de réel besoin d'implémenter l'interface ICustomer dans ce cas présent
    {
        public int Discount { get; set; }
        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }
        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }
        public string CombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("Empty firstName");

            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100) return new BasicCustomer();
            else return new PlatinumCustomer();
        }
    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}
