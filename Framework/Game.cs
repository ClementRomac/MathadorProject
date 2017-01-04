using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public abstract class Game
    {
        public List<DrawResolution> Historical { get; private set; }
        private DrawResolution currentDraw;
        public string Pseudo { get; private set; }
        public Game(string pseudo)
        {
            Historical = new List<DrawResolution>();
            Pseudo = pseudo;
        }

        public void AddDrawResolution(Draw draw)
        {
            currentDraw = new DrawResolution(draw);
            Historical.Add(currentDraw);
        }

        public void AddStroke(Stroke stroke)
        {
            if (!currentDraw.IsFinished())
            {
                currentDraw.AddStroke(stroke);
            }
        }

        public int GetTotalPoints()
        {
            int points = 0;
            Historical.ForEach(d => points += d.GetCurrentPoints());

            return points;
        }
    }
}
