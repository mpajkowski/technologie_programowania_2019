﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private readonly string OUT_JSON_PATH = "json_outcome.json";
        private readonly string IN_JSON_PATH = "json_income.json";
        

        private void PerformanceJsonDataFillerInternal()
        {
            dataSerializer = new JsonDataSerializer(IN_JSON_PATH);
            DataContext jsonFilledDataContext = new DataContext();
            {
                var jsonDataFiller = new FileDataFiller(dataSerializer);
                jsonDataFiller.Fill(ref jsonFilledDataContext);
            }
        }

        private void PerformanceConstDataTestInternal()
        {
            var constFilledDataContext = new DataContext();
            {
                var constDataFiller = new ConstDataFiller();
                constDataFiller.Fill(ref constFilledDataContext);
            }
        }

        [TestMethod()]
        public void Performance10000TimesFillConstDataFill()
        {
            for (int i = 0; i < 10000; ++i)
            {
                PerformanceConstDataTestInternal();
            }
        }

        [TestMethod()]
        public void Performance1000TimesFillConstDataFill()
        {
            for (int i = 0; i < 1000; ++i)
            {
                PerformanceConstDataTestInternal();
            }
        }

        [TestMethod()]
        public void Performance100TimesConstDataFill()
        {
            for (int i = 0; i < 100; ++i)
            {
                PerformanceConstDataTestInternal();
            }
        }

        [TestMethod()]
        public void Performance10TimesConstDataFill()
        {
            for (int i = 0; i < 10; ++i)
            {
                PerformanceConstDataTestInternal();
            }
        }

        [TestMethod()]
        public void Performance10000TimesJsonFill()
        {
            for (int i = 0; i < 10000; ++i)
            {
                PerformanceJsonDataFillerInternal();
            }
        }

        [TestMethod()]
        public void Performance1000TimesJsonFill()
        {
            for (int i = 0; i < 1000; ++i)
            {
                PerformanceJsonDataFillerInternal();
            }
        }

        [TestMethod()]
        public void Performance100TimesJsonFill()
        {
            for (int i = 0; i < 100; ++i)
            {
                PerformanceJsonDataFillerInternal();
            }
        }

        [TestMethod()]
        public void Performance10TimesJsonFill()
        {
            for (int i = 0; i < 10; ++i)
            {
                PerformanceJsonDataFillerInternal();
            }
        }

        [TestMethod()]
        public void FillTest()
        {
            dataSerializer = new JsonDataSerializer(OUT_JSON_PATH);
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

            Assert.AreEqual(constFilledDataContext, jsonFilledDataContext);
        }
    }
}