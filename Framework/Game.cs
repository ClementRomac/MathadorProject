using System;
using System.Collections.Generic;

namespace Framework
{
    public class Game
    {
        public List<DrawResolution> Historical { get; private set; }

        private DrawResolution currentDrawResolution;

        public DateTime BeginTime;

        public DateTime FinishTime;
        public GameType gameType { get; private set; }
        public string Pseudo { get; private set; }
        public Game(string pseudo, GameType gameType)
        {
            Historical = new List<DrawResolution>();
            Pseudo = pseudo;
            this.gameType = gameType;
        }

        public void AddDrawResolution(Draw draw)
        {
            currentDrawResolution = new DrawResolution(draw);
            Historical.Add(currentDrawResolution);
        }

        public void SetCurrentDrawResolutionSavedPoints(int points)
        {
            currentDrawResolution.SavedCurrentPoints = points;
        }
        //public int GetCurrentDrawResolutionPoints()
        //{
        //    currentDrawResolution.GetCurrentPoints();
        //    return currentDrawResolution.SavedCurrentPoints;
        //}

        public void AddStroke(Stroke stroke, Stroke fromStroke1 = null, Stroke fromStroke2 = null)
        {
            if (!currentDrawResolution.IsFinished())
            {
                currentDrawResolution.AddStroke(stroke, fromStroke1 ,fromStroke2);
            }
        }

        public bool IsCurrentDrawResolutionFinished()
        {
            return currentDrawResolution.IsFinished();
        }

        public int GetTotalPoints()
        {
            int points = 0;
            Historical.ForEach(d => points += d.GetCurrentPoints());

            return points;
        }

        public int GetSavedTotalPoints()
        {
            int points = 0;
            Historical.ForEach(d => points += d.SavedCurrentPoints);

            return points;
        }

        public string GetTimeOfGame()
        {
            switch (gameType)
            {
                case GameType.AgainstTime:
                    return (new DateTime().AddMinutes(3) - (FinishTime - BeginTime)).ToString("mm\\:ss");
                case GameType.Fastest:
                    return (FinishTime - BeginTime).ToString("mm\\:ss");
                default:
                    return (FinishTime - BeginTime).ToString("mm\\:ss");
            }
        }
    }
}
