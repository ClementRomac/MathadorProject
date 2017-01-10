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


        public DrawList(List<Draw> fileContent)
        {
            draws = fileContent;
            cursor = -1;
        }

        public Draw GetNext()
        {
            return draws.ElementAt(cursor++);
        }
    }
}
