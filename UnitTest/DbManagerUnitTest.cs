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
            List<Department> res = managet.GetDepartments();
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

        [TestMethod]
        public void GetEmployeeByIDTest()
        {
            int id = 1;
            Employee res = managet.GetEmployee(id);
            Assert.IsTrue(res != null && res.Id == id);
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            int id = 1;
            Employee control = managet.GetEmployee(id);
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("FirstName",control.FirstName+control.FirstName);
            pars.Add("Position", control.Position + control.Position);
            Assert.IsTrue(managet.UpdateEmployee(id,pars));

            Employee updateItem = managet.GetEmployee(id);

            Assert.IsTrue(updateItem.FirstName.Equals(control.FirstName + control.FirstName));
            Assert.IsTrue(updateItem.Position.Equals(control.Position + control.Position));
            pars["FirstName"] = control.FirstName;
            pars["Position"] = control.Position;

            Assert.IsTrue(managet.UpdateEmployee(id, pars));

            Employee result = managet.GetEmployee(id);
            Assert.IsTrue(control.Equals(result));
        }

        public void DeleteAndInsertEmployeeTest()
        {
            int id = 1;
            Employee controll = managet.GetEmployee(id);
        }
    }
}
