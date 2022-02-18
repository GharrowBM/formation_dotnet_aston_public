using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public interface IMovable
    {
        public void MoveForward(double distance);
        public void MoveBackward(double distance);
    }
}
