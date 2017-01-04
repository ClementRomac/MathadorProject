using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Stroke> GetSolution()
        {
            throw new NotImplementedException();
        }
    }
}
