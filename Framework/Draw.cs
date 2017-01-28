using System.Collections.Generic;

namespace Framework
{
    public class Draw
    {
        public List<int> Numbers
        {
            get;
            private set;
        }

        public int Goal { get; private set; }

        public Draw(List<int> numbers, int goal)
        {
            Numbers = numbers;
            Goal = goal;
        }

        public override string ToString()
        {
            return "Tirage : " + 
                Numbers[0].ToString() + ", " +
                Numbers[1].ToString() + ", " +
                Numbers[2].ToString() + ", " +
                Numbers[3].ToString() + ", " +
                Numbers[4].ToString() + " - Objectif : " +
                Goal.ToString();
        }
    }
}
