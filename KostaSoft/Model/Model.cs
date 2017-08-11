using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
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
                    employeeEventArgs.DepNameList = DepartmentNames;
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


    }
}
