using Framework;
using Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Generator
{
    public class DrawGenerator
    {
        private static Random random = new Random();
        public DrawGenerator(int max, string path)
        {
            List<Draw> generatedDraws = new List<Draw>();
            for (int i = 0; i < max; i++)
            {
                Draw tmp = Generate();
                generatedDraws.Add(tmp);
            }

            DAO.FileHandler fileHandler = new DAO.FileHandler(path);
            try
            {
                fileHandler.WriteFile(generatedDraws, GenerateName(generatedDraws.Count));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private Draw Generate()
        {
            Draw generatedDraw = null;
            do
            {
                List<int> numbers = new List<int>();
                numbers.Add(random.Next(1, 12));
                numbers.Add(random.Next(1, 12));
                numbers.Add(random.Next(1, 20));
                numbers.Add(random.Next(1, 20));
                numbers.Add(random.Next(1, 20));
                int goal = random.Next(1, 100);

                generatedDraw = new Draw(numbers, goal);

            } while (!DrawSolver.IsPossible(generatedDraw));

            return generatedDraw;
        }

        private string GenerateName(int numberOfDraws)
        {
            DateTime date = DateTime.Now;
            string name = string.Join("-", new string[] {
                date.Year.ToString(),
                date.Month.ToString(),
                date.Day.ToString(),
                date.Hour.ToString(),
                date.Minute.ToString(),
                date.Second.ToString(),
                numberOfDraws.ToString()
            });

            return name + ".json";
        }
    }
}
