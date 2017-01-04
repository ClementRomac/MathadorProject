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
        public DrawGenerator(int max)
        {
            List<Draw> generatedDraws = new List<Draw>();
            for (int i = 0; i < max; i++)
            {
                Draw tmp = Generate();
                generatedDraws.Add(tmp);
            }

            WriteResults(generatedDraws);
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

        private void WriteResults(List<Draw> generatedDraws)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(@"..\..\..\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, generatedDraws);
            }
        }
    }
}
