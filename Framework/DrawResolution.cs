using System.Collections.Generic;
using System.Linq;

namespace Framework
{
    public class DrawResolution
    {
        public Draw Draw { get; private set; }
        public List<Stroke> Strokes { get; private set; }

        private Dictionary<MathadorOperators, int> usedOperators;
        public int LastResult { get; private set; }
        public DrawResolution(Draw draw)
        {
            Draw = draw;
            LastResult = 0;
            Strokes = new List<Stroke>();
            usedOperators = new Dictionary<MathadorOperators, int>();
            usedOperators.Add(MathadorOperators.Addition, 0);
            usedOperators.Add(MathadorOperators.Substraction, 0);
            usedOperators.Add(MathadorOperators.Multiplication, 0);
            usedOperators.Add(MathadorOperators.Division, 0);
        }

        public void AddStroke(Stroke stroke)
        {
            if(!IsFinished())
            {
                Strokes.Add(stroke);
                LastResult = stroke.Result;
                usedOperators[stroke.Operator] += 1;
            }
        }

        public int GetCurrentPoints()
        {
            int points = 0;
            if(IsMathadorPlay())
            {
                points = 13;
            }
            else
            {
                Strokes.ForEach(s => points += s.GetPoints());
            }

            return points;
        }

        public bool IsFinished()
        {
            return Strokes.Count == 4;
        }

        private bool IsMathadorPlay()
        {
            return usedOperators.Where(o => o.Value == 1).Count() == 4 && IsGoalReached();
        }

        public bool IsGoalReached()
        {
            return LastResult == Draw.Goal;
        }

        public bool HasAnyStrokeReachedTheGoal()
        {
            return Strokes.Any(s => s.Result == Draw.Goal) ;
        }
    }
}
