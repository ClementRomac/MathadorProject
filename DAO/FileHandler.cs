using Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FileHandler
    {
        private string path;

        public FileHandler(string path)
        {
            this.path = path;
        }

        public void WriteFile(List<Draw> generatedDraws, string name)
        {
            JsonSerializer serializer = new JsonSerializer();

            try
            {
                using (StreamWriter sw = new StreamWriter(@path + name))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, generatedDraws);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
