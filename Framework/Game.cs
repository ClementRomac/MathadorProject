using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Game
    {
        public List<DrawResolution> Historical { get; private set; }
        private DrawResolution currentDrawResolution;
        public string Pseudo { get; private set; }
        public Game(string pseudo)
        {
            Historical = new List<DrawResolution>();
            Pseudo = pseudo;
        }

        public void AddDrawResolution(Draw draw)
        {
            currentDrawResolution = new DrawResolution(draw);
            Historical.Add(currentDrawResolution);
        }

        public int GetCurrentDrawResolutionPoints()
        {
            return currentDrawResolution.GetCurrentPoints();
        }

        public void AddStroke(Stroke stroke)
        {
            if (!currentDrawResolution.IsFinished())
            {
                currentDrawResolution.AddStroke(stroke);
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
