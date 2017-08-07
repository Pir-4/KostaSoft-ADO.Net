using System;
using DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
