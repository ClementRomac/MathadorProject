using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class DrawList
    {
        private int cursor;
        private List<Draw> draws;

        public DrawList(string fileContent)
        {
            draws = new List<Draw>();
            cursor = -1;
            throw new NotImplementedException();
        }

        public Draw GetNext()
        {
            return draws.ElementAt(cursor++);
        }
    }
}
