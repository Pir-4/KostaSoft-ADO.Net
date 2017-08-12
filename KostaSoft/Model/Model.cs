using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using KostaSoft.Model.Command;
using KostaSoft.Model.EventAgrs;
using KostaSoft.Model.Observers;

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
        private event ModelEmplHandler<Model> modelEmplHandlerMassage;
        private event ModelEmplHandler<Model> modelEmplHandlerId;

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

        public void attach(IEmployeeObserver imo)
        {
            modelEmplHandlerMassage += new ModelEmplHandler<Model>(imo.UpdateMassage);
            modelEmplHandlerId += new ModelEmplHandler<Model>(imo.GetId);
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

        

        #region Employee

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
                employeeEventArgs.Message = result ? "Сохранено." : "Не сохранилось.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                employeeEventArgs.Message = String.Format("Ошибка. {0}", e.Message);
            }
            finally
            {
                modelEmplHandlerMassage.Invoke(this,employeeEventArgs);
                UpdateTree();
            }

        }

        public void DeleteEmployee(int id)
        {

            try
            {
                bool result = manager.DeleteEmployee(id);
                employeeEventArgs.Message = result ? "Удалено." : "Не удалилось.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                employeeEventArgs.Message = String.Format("Ошибка. {0}", e.Message);
            }
            finally
            {
                modelEmplHandlerMassage.Invoke(this, employeeEventArgs);
                UpdateTree();
            }
            
        }

        public void NewEmployee(EmployeeCommand command)
        {
            try
            {
                bool result = manager.InsertEmployee(GetParam(command));
                employeeEventArgs.Message = result ? "Новый сотрудник создан." : "Новый сотрудник не создан.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                employeeEventArgs.Message = String.Format("Ошибка. {0}", e.Message);
            }
            finally
            {
                modelEmplHandlerMassage.Invoke(this, employeeEventArgs);
                int maxId = 0;
                foreach(Employee emp in Employees)
                    if (emp.Id > maxId)
                        maxId = emp.Id;

                UpdateTree();

                foreach (Employee emp in Employees)
                    if (emp.Id > maxId)
                    {
                        employeeEventArgs.Id = emp.Id;
                        break;
                    }
                modelEmplHandlerId.Invoke(this,employeeEventArgs);
            }
           
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
        #endregion

        #region Departament

        private bool GetDepartmentItem(string name)
        {
            try
            {
                List<Department> dep = Departments.Where(item => item.Name.Equals(name)).ToList();

                if (dep.Count > 0)
                {
                    departmentEventsArgs.DisplayDep = dep[0];
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
                result.Add("ParentDepartmentID", dep[0].Id);
            }
            return result;
        }


        #endregion




    }
}
