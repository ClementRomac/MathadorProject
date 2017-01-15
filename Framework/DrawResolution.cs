using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class DrawResolution
    {
        public Draw Draw { get; private set; }
        public List<Stroke> Strokes { get; private set; }

        private Dictionary<MathadorOperators, int> usedOperators;
        public int lastResult { get; private set; }
        public DrawResolution(Draw draw)
        {
            Draw = draw;
            lastResult = 0;
            Strokes = new List<Stroke>();
            usedOperators = new Dictionary<MathadorOperators, int>();
            usedOperators.Add(MathadorOperators.Addition, 0);
            usedOperators.Add(MathadorOperators.Substraction, 0);
            usedOperators.Add(MathadorOperators.Multiplication, 0);
            usedOperators.Add(MathadorOperators.Division, 0);
        }

        public void AddStroke(Stroke stroke)
        {
            if(IsFinished())
            {
                Strokes.Add(stroke);
                lastResult = stroke.Result;
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
            return usedOperators.Select(o => o.Value == 1).Count() == 4;
        }

        public bool IsGoalReached()
        {
            return lastResult == Draw.Goal;
        }
    }
}
