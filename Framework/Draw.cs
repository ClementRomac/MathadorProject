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
    }
}
