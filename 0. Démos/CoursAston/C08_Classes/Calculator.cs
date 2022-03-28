using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08_Classes
{
    public class Calculator
    {
        public List<int> NumberRange = new();
        public int AddNumbers(int nbA, int nbB)
        {
            return nbA + nbB;
        }

        public double AddNumbersDouble(double dbA, double dbB)
        {
            return dbA + dbB;
        }

        public int SubstractNumbers(int nbA, int nbB)
        {
            return nbA - nbB;
        }

        public int MultiplyNumbers(int nbA, int nbB)
        {
            return nbA * nbB;
        }

        public double DivideNumbers(int nbA, int nbB)
        {
            return (double)nbA / (double)nbB;
        }

        public int ModulusNumbers(int nbA, int nbB)
        {
            return nbA % nbB;
        }

        public double ExecuteOperation(int nbA, int nbB, char operand = '%')
        {
            switch (operand)
            {
                case '+':
                    return AddNumbers(nbA, nbB);
                case '-':
                    return SubstractNumbers(nbA, nbB);
                case '*':
                    return MultiplyNumbers(nbA, nbB);
                case '/':
                    return DivideNumbers(nbA, nbB);
                default:
                    return ModulusNumbers(nbA, nbB);

            }
        }

        public bool IsOddNumber(int nbA)
        {
            return nbA % 2 != 0;
        }

        public List<int> GetOddRange(int min, int max)
        {
            NumberRange.Clear();

            for (int i = min; i <= max; i++) if (i % 2 != 0) NumberRange.Add(i);

            return NumberRange;
        }
    }
}
