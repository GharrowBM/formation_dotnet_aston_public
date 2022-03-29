using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03B_Classes
{
    public class Game
    {
        private List<Frame> _frames;
        private int _globalScore;

        public List<Frame> Frames { get => _frames; set => _frames = value; }
        public int GlobalScore { get => _globalScore; set => _globalScore = value; }

        public Game()
        {
            _frames = new List<Frame>();
        }
    }
}
