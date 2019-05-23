using System;
using System.IO;
using Newtonsoft.Json;

namespace application
{
    public class JsonDataSerializer : IDataSerializer
    {
        public JsonDataSerializer(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; private set; }

        public void Serialize(DataContext dataContext)
        {
            using (var writer = new StreamWriter(FilePath))
            {
                using (var textWriter = new JsonTextWriter(writer))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(textWriter, dataContext);
                }
            }
        }

        public DataContext Deserialize()
        {
            DataContext context = null;

            using (var reader = new StreamReader(FilePath))
            {
                using (var textReader = new JsonTextReader(reader))
                {
                    var serializer = new JsonSerializer();
                    context = (DataContext)serializer.Deserialize(textReader, typeof(DataContext));
                }
            }

            return (DataContext)context;
        }
    }
}
