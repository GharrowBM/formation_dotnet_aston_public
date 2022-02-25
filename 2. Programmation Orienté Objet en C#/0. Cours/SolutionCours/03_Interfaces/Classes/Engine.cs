using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Interfaces.Classes
{
    internal class Engine
    {
        private double _actualVolume;
        private double _maxVolume;
        private bool _isStarted;

        public Engine(double maxVolume)
        {
            _actualVolume = _maxVolume = maxVolume;
            _isStarted = false;
        }

        public void SwitchRunning()
        {
            if (!_isStarted && _actualVolume >= 0.5)
            {
                _actualVolume -= 0.5;
                _isStarted = true;
            }
            else
            {
                _isStarted = false;
            }
        }

        public double Run(double amount)
        {
            if (_actualVolume - amount > 0) _actualVolume -= amount;

            return _actualVolume;
        }

        public double Fill(double amount)
        {
            _actualVolume += amount;

            if(_actualVolume > _maxVolume) _actualVolume = _maxVolume;

            return _actualVolume;
        }


    }
}
