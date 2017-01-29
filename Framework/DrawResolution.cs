using System.Collections.Generic;
using System.Linq;
using System;

namespace Framework
{
    public class DrawResolution
    {
        public Draw Draw { get; private set; }
        public List<Stroke> Strokes { get; private set; }
        private StrokesDictionary strokesDictionary;
        private Dictionary<MathadorOperators, int> usedOperators;
        public int SavedCurrentPoints;
        public DrawResolution(Draw draw)
        {
            strokesDictionary = new StrokesDictionary();
            Draw = draw;
            Strokes = new List<Stroke>();
            usedOperators = new Dictionary<MathadorOperators, int>();
            usedOperators.Add(MathadorOperators.Addition, 0);
            usedOperators.Add(MathadorOperators.Substraction, 0);
            usedOperators.Add(MathadorOperators.Multiplication, 0);
            usedOperators.Add(MathadorOperators.Division, 0);
        }

        public void AddStroke(Stroke stroke, Stroke fromStroke1=null, Stroke fromStroke2=null) 
        {
            if(!IsFinished())
            {
                Strokes.Add(stroke);
                int result = stroke.Result;               
                usedOperators[stroke.Operator] += 1;

                SetStrokesDictionary(stroke, fromStroke1, fromStroke2);
            }
        }

        public int GetCurrentPoints()
        {
            int points = 0;
            if (IsGoalReached())
            {
                if (IsMathadorPlay())
                {
                    points = 13;
                }
                else
                {
                    List<Tuple<Stroke, List<Stroke>>> strokesWithGoalReachedList =
                        strokesDictionary.Where(t => t.Item1.Result == Draw.Goal).ToList();

                    int tmpPoints = 0;
                    foreach(Tuple<Stroke, List<Stroke>> strokeWithGoalReached in strokesWithGoalReachedList)
                    {
                        strokeWithGoalReached.Item2.ForEach(s => tmpPoints += s.GetPoints());
                        if (tmpPoints > points)
                            points = tmpPoints;
                    }
                    
                }
            }

            SavedCurrentPoints = points;
            return points;
        }

        public bool IsFinished()
        {
            return Strokes.Count == 4;
        }

        private bool IsMathadorPlay()
        {
            return usedOperators.Where(o => o.Value == 1).Count() == 4;
        }

        public bool IsGoalReached()
        {
            return strokesDictionary.Where(t => t.Item1.Result == Draw.Goal).Count() > 0;
        }

        public bool HasAnyStrokeReachedTheGoal()
        {
            return Strokes.Any(s => s.Result == Draw.Goal);
        }

        private void SetStrokesDictionary(Stroke stroke, Stroke fromStroke1, Stroke fromStroke2)
        {
            System.Tuple<Stroke, List<Stroke>> currentStrokeinDictionary = 
                new System.Tuple<Stroke, List<Stroke>>(
                    stroke,
                    new List<Stroke>() { stroke }
                );

            if (fromStroke1 != null)
            {
                int fromStroke1Index = strokesDictionary.IndexOf(
                    strokesDictionary.Where(t => t.Item1.Equals(fromStroke1)).FirstOrDefault());

                currentStrokeinDictionary.Item2.AddRange(strokesDictionary[fromStroke1Index].Item2);
                strokesDictionary.RemoveAt(fromStroke1Index);
            }


            if (fromStroke2 != null)
            {
                int fromStroke2Index = strokesDictionary.IndexOf(
                    strokesDictionary.Where(t => t.Item1.Equals(fromStroke2)).FirstOrDefault());

                currentStrokeinDictionary.Item2.AddRange(strokesDictionary[fromStroke2Index].Item2);
                strokesDictionary.RemoveAt(fromStroke2Index);
            }

            strokesDictionary.Add(currentStrokeinDictionary);
        }
    }
}
