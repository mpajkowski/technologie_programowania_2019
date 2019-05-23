using Microsoft.VisualStudio.TestTools.UnitTesting;
using application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Tests
{
    [TestClass()]
    public class FileDataFillerTests
    {
        private IDataSerializer dataSerializer;
        private string FILE_PATH = "testfile.json";
        
        [TestInitialize]
        public void SetUp()
        {
            dataSerializer = new JsonDataSerializer(FILE_PATH);
        }

        [TestMethod()]
        public void FillTest()
        {
            // first create a data context and fill using well-tested ConstDataFiller
            var constFilledDataContext = new DataContext();
            {
                var constDataFiller = new ConstDataFiller();
                constDataFiller.Fill(ref constFilledDataContext);
            }

            // serialize the data using JsonDataSerializer
            dataSerializer.Serialize(constFilledDataContext);

            // read the data from the storage
            DataContext jsonFilledDataContext = new DataContext();
            {
                var jsonDataFiller = new FileDataFiller(dataSerializer);
                jsonDataFiller.Fill(ref jsonFilledDataContext);
            }

            // compare the results
            Assert.AreEqual(constFilledDataContext, jsonFilledDataContext);
        }
    }
}