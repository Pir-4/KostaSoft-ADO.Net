using System;
using System.Collections.Generic;
using DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class DbManagerUnitTest
    {
        private DbManager managet = new DbManager();

        [TestMethod]
        public void GetDepartmentsTest()
        {
            List < Department > res= managet.GetDepartments();
            Assert.IsTrue(res.Count != 0);
        }

        [TestMethod]
        public void GetEmployeeTest()
        {
            List<Employee> res = managet.GetEmployee();
            Assert.IsTrue(res.Count != 0);
        }

        [TestMethod]
        public void GetEmployeeByDepartmentIDTest()
        {
            List<Employee> res = managet.GetEmployee("fb9d1a43-5796-4190-abd4-39ffd8c87476");
            Assert.IsTrue(res.Count != 0);
        }
    }
}
