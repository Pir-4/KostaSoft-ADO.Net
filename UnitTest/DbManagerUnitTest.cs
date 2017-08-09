using System;
using System.Collections.Generic;
using System.Linq;
using DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class DbManagerUnitTest
    {
        private DbManager managet = new DbManager();

        private Dictionary<string, string> ConvertEmployee(Employee employee)
        {
            return new Dictionary<string, string>
            {
                {"ID",employee.Id.ToString()},
                {"DepartmentID",employee.DepartmentID},
                {"SurName",employee.SurName},
                {"FirstName",employee.FirstName},
                {"Patronymic",employee.Patronymic},
                {"DateOfBirth",employee.DateOfBirth.ToString()},
                {"DocSeries",employee.DocSeries},
                {"DocNumber",employee.DocNumber},
                {"Position",employee.Position},
            };
        }
        [TestMethod]
        public void GetDepartmentsTest()
        {
            List<IOrgItem> res = managet.GetDepartments();
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
            List<Employee> res = managet.GetEmployee("0049AB7F-DB91-4C93-BFE9-B91D62F3FA17");
            Assert.IsTrue(res.Count != 0);
        }

        [TestMethod]
        public void GetEmployeeByIDTest()
        {
            Employee em = managet.GetEmployee()[0];
            Employee res = managet.GetEmployee(em.Id);
            Assert.IsTrue(res != null && res.Id == em.Id);
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            Employee em = managet.GetEmployee()[0];
            Employee control = managet.GetEmployee(em.Id);
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("FirstName",control.FirstName+control.FirstName);
            pars.Add("Position", control.Position + control.Position);
            Assert.IsTrue(managet.UpdateEmployee(em.Id, pars));

            Employee updateItem = managet.GetEmployee(em.Id);

            Assert.IsTrue(updateItem.FirstName.Equals(control.FirstName + control.FirstName));
            Assert.IsTrue(updateItem.Position.Equals(control.Position + control.Position));
            pars["FirstName"] = control.FirstName;
            pars["Position"] = control.Position;

            Assert.IsTrue(managet.UpdateEmployee(em.Id, pars));

            Employee result = managet.GetEmployee(em.Id);
            Assert.IsTrue(control.Equals(result));
        }

        [TestMethod]
        public void DeleteAndInsertEmployeeTest()
        {
            Employee control = new Employee();
            control.DepartmentID = "fb9d1a43-5796-4190-abd4-39ffd8c87476";
            control.SurName = "test";
            control.FirstName = "test";
            control.Patronymic = "test";
            control.DateOfBirth = new DateTime(2017,3,12);
            control.DocSeries = "test";
            control.DocNumber = "test";
            control.Position = "test";
            Assert.IsTrue(managet.InsertEmployee(ConvertEmployee(control)));
            List<Employee> list= managet.GetEmployee().Where( item => item.SurName == control.SurName).ToList();
            Assert.IsTrue(list.Count >0);
            Employee result = managet.GetEmployee(list[0].Id);
            control.Id = result.Id;
            //bool t = ;
            Assert.IsTrue(control.Equals(result));
            Assert.IsTrue(managet.DeleteEmployee(result.Id));
            Assert.IsNull(managet.GetEmployee(result.Id));
        }
    }
}
