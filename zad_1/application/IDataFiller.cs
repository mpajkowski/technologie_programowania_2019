using casino;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    public interface IDataFiller
    {
        void Fill(ref DataContext dataContext);
    }
}
