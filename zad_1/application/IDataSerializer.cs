using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public interface IDataSerializer
    {
        void Serialize(DataContext dataContext);
        DataContext Deserialize();
    }
}
