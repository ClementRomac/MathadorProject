using System;
using System.Collections.Generic;
using System.IO;
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
            if (!File.Exists("../../../Game/bin/Debug/matador.sql"))
            {
                test.CreateFile();
            }

            //Test insert
            // test.InsertIntoGamer("test");
            test.InsertIntoGamer("test");
            test.InsertIntoGamer("test2");
            test.SelectAllGamer();
            test.InsertIntoGame(DateTime.Now.AddMinutes(1), DateTime.Now ,1, 2);
            //test.InsertIntoStroke(1, 4, '+' , 2);
            //test.InsertIntoSolution(" 4+5/8-9*9", 1);
            //test.InsertIntoDrawList(1, 1, 5, 4, 8, 9, 45);

            //TestREAD /
            //int test2 = test.SelectDrawListIdGame(1,5,4,8,9,45);


        }
    }
}
