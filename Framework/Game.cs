using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public abstract class Game
    {
        private Dictionary<Draw, List<Stroke>> historical;
        public Game()
        {
            historical = new Dictionary<Draw, List<Stroke>>();
        }

        public void AddDraw(Draw draw)
        {
            historical.Add(draw, new List<Stroke>());
        }

        public void AddStroke(Draw draw, Stroke stroke)
        {
            throw new NotImplementedException();
        }
    }
}
