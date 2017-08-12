using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using KostaSoft.Model.Command;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft.Model
{

    public class Model : IModel
    {
        delegate void ModelUpdateHandler<IModel>(IModel sender, UpdateTreeEventArgs e);
        delegate void ModelDeptHandler<IModel>(IModel sender, DepartmentEventsArgs e);
        delegate void ModelEmplHandler<IModel>(IModel sender, EmployeeEventArgs e);

        UpdateTreeEventArgs updateTreeEventArgs = new UpdateTreeEventArgs();
        DepartmentEventsArgs departmentEventsArgs = new DepartmentEventsArgs();
        EmployeeEventArgs employeeEventArgs = new EmployeeEventArgs();

        private event ModelUpdateHandler<Model> modelHedlerUpdateTree;
        private event ModelDeptHandler<Model> modelDeptHandler;
        private event ModelEmplHandler<Model> modelEmplHandler;

        DbManager manager = new DbManager();
        OrgBuilder builder = new OrgBuilder();

        private List<Department> Departments { get; set; }
        private List<Employee> Employees { get; set; }
        private List<String> DepartmentNames
        {
            get { return Departments.Select(item => item.Name).ToList(); }
        }

        public void attach(IModelObserver imo)
        {
            modelHedlerUpdateTree += new ModelUpdateHandler<Model>(imo.UpdateTree);
            modelDeptHandler += new ModelDeptHandler<Model>(imo.DepartmentItem);
            modelEmplHandler += new ModelEmplHandler<Model>(imo.EmployeeEItem);
        }

        public void UpdateTree()
        {
            Departments = manager.GetDepartments();
            Employees = manager.GetEmployee();

            builder.Sotring(Departments.Cast<IOrgItem>().ToList());
            builder.Sotring(Employees.Cast<IOrgItem>().ToList());

            updateTreeEventArgs.Root = builder.Root;
            updateTreeEventArgs.DepNameList = DepartmentNames;
            modelHedlerUpdateTree.Invoke(this, updateTreeEventArgs);
        }

        public void GetInfoItem(string name)
        {
            bool result = GetDepartmentItem(name) || GetEmployeeItem(name);
        }

        private bool GetDepartmentItem(string name)
        {
            try
            {
                List<Department> dep = Departments.Where(item => item.Name.Equals(name)).ToList();

                if (dep.Count > 0)
                {
                    departmentEventsArgs.DisplayDep = dep[0];
                    departmentEventsArgs.DepNameList = DepartmentNames;
                    modelDeptHandler(this, departmentEventsArgs);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return false;
        }

        private bool GetEmployeeItem(string name)
        {
            try
            {
                List<Employee> emp = Employees.Where(item => item.Name.Equals(name)).ToList();
                if (emp.Count > 0)
                {
                    employeeEventArgs.DisplayEmp = emp[0];
                    modelEmplHandler(this, employeeEventArgs);
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;

        }

        public void SaveEmployee(EmployeeCommand command)
        {
            try
            { 
                bool result = manager.UpdateEmployee(command.Id, GetParam(command));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                UpdateTree();
            }
           
        }

        public void DeleteEmployee(int id)
        {
            manager.DeleteEmployee(id);
            UpdateTree();
        }

        public void NewEmployee(EmployeeCommand command)
        {
            manager.InsertEmployee(GetParam(command));
            UpdateTree();
        }

        public void SaveDepartament(DepartmentCommand command)
        {
            bool result = manager.UpdateDepartments(command.Id, GetParam(command));
            UpdateTree();
        }

        public void NewDepartment(DepartmentCommand command)
        {
            bool result = manager.InsertDepartments(GetParam(command));
            UpdateTree();
        }

        private Dictionary<string, string> GetParam(EmployeeCommand command)
        {
            List<Department> dep = Departments.Where(item => item.Name.Equals(command.DepartmentName)).ToList();

            return new Dictionary<string, string>()
            {
                { "DepartmentID", dep[0].Id},

                { "SurName", command.SurName},
                { "FirstName", command.FirstName},
                { "Patronymic", command.Patronymic},

                { "DateOfBirth", command.DateOfBirth.ToString()},

                { "DocSeries", command.DocSeries},
                { "DocNumber", command.DocNumber},
                { "Position", command.Position},
            };
        }

        private Dictionary<string, string> GetParam(DepartmentCommand command)
        {
            Dictionary<string, string> result = new Dictionary<string, string>()
            {
                { "Code", command.Code},
                { "Name", command.Name},
            };

            if (command.ParentDepartmentName != null)
            {
                List<Department> dep = Departments.Where(item => item.Name.Equals(command.ParentDepartmentName)).ToList();
                result.Add("ParentDepartmentID",dep[0].Id);
            }
            return result;
        }



    }
}
