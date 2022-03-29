using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03B_Classes
{
    public class Frame
    {
        private int _score;
        private List<Roll> _rolls;
        private bool _lastFrame;
        private IGenerator _generator;


        public int Score
        {
            get
            {
                int score = 0;
                Rolls.ForEach(r =>
                {
                    score += r.Pins;
                });
                return score;
            }
        }
        public bool LastFrame { get => _lastFrame; set => _lastFrame = value; }
        public List<Roll> Rolls { get => _rolls; set => _rolls = value; }

        public Frame(IGenerator g, bool lastFrame)
        {
            _generator = g;
            _score = 0;
            Rolls = new List<Roll>();
            LastFrame = lastFrame;
        }


        private void MakeRoll(int max)
        {
            int randomPins = _generator.RandomPins(max);
            Rolls.Add(new Roll(randomPins));
        }
        public bool Roll()
        {
            int nbRolls = Rolls.Count;
            if (nbRolls == 0 || (nbRolls == 1 && Rolls[0].Pins == 10 && _lastFrame))
            {
                MakeRoll(10);
            }
            else if (nbRolls == 1 && !(Rolls[0].Pins == 10 && !_lastFrame))
            {
                MakeRoll(10 - Rolls[0].Pins);
            }
            else if (nbRolls == 2 && _lastFrame)
            {
                Roll r1 = Rolls[0];
                Roll r2 = Rolls[1];
                if ((r1.Pins + r2.Pins) >= 10)
                {
                    int max = 20 - (r1.Pins + r2.Pins);
                    MakeRoll(max);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
