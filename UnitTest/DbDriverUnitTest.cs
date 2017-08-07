using System;
using DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace UnitTest
{
    [TestClass]
    public class DbDriverUnitTest
    {
        private DbDriver driver = new DbDriver();
        [TestMethod]
        public void SelectTest()
        {
            driver.Select();
        }

        [TestMethod]
        public void ExecuteReader()
        {
            driver.ExecuteReader("Select * From Department");
        }
    }
}
