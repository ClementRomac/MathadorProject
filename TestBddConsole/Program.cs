using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBddConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DAO.BDDHandler test = new DAO.BDDHandler();
            test.CreateFile();

        }
    }
}
