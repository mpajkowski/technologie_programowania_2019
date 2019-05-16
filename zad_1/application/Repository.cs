using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    class Repository
    {
        private DataContext dataContext;
        private IDataFiller dataFiller;

        Repository(IDataFiller dataFiller)
        {
            this.dataFiller = dataFiller;
            this.dataContext = new DataContext();

            dataFiller.Fill(ref dataContext);
        }
    }
}
