using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03B_Classes
{
    public interface IGenerator
    {
        int RandomPins(int max);
    }
    public class PinNumberGenerator : IGenerator
    {
        public int RandomPins(int max)
        {
            throw new NotImplementedException();

            //var rnd = new Random();
            //return rnd.Next(max + 1);
        }
    }
}
