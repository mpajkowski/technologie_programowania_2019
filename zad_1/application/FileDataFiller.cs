using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public class FileDataFiller : IDataFiller
    {
        public FileDataFiller(IDataSerializer serializer)
        {
            Serializer = serializer;
        }

        public IDataSerializer Serializer { get; set; }

        public void Fill(ref DataContext dataContext)
        {
            dataContext = Serializer.Deserialize();
        }
    }
}
