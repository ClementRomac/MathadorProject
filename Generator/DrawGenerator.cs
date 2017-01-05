using Framework;
using Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

            WriteResults(generatedDraws, path);
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

        private void WriteResults(List<Draw> generatedDraws, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            try
            {
                using (StreamWriter sw = new StreamWriter(@path + "json.txt"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, generatedDraws);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
