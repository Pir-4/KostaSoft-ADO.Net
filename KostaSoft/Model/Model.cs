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
        private event ModelDeptHandler<Model> modelDeptHandlerMessage;
        private event ModelDeptHandler<Model> modelDeptHandlerId;

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

        public void attach(IDepartmentObserver imo)
        {
            modelDeptHandlerMessage += new ModelDeptHandler<Model>(imo.UpdateMessage);
            modelDeptHandlerId += new ModelDeptHandler<Model>(imo.GetId);
        }
        /// <summary>
        /// Обновление структуры организации
        /// </summary>
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

        /// <summary>
        /// Запрос на получение информации об элемента организации
        /// </summary>
        /// <param name="name"></param>
        public void OpenItem(string name)
        {
            bool result = GetDepartmentItem(name) || GetEmployeeItem(name);
        }



        #region Employee

        /// <summary>
        /// Получение данных о сотруднике
        /// </summary>
        /// <param name="name"> полное имя сотрудника</param>
        /// <returns></returns>
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

        /// <summary>
        /// Сохранение измененных параметров у сотрудника
        /// </summary>
        /// <param name="command"></param>
        public void SaveChange(EmployeeCommand command)
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
                modelEmplHandlerMassage.Invoke(this, employeeEventArgs);
                UpdateTree();
            }

        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id">идентификатор сотрудника</param>
        public void Delete(int id)
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

        /// <summary>
        /// СОхранение нового сотрудника
        /// </summary>
        /// <param name="command"></param>
        public void SaveNew(EmployeeCommand command)
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

                IEnumerable<int> oldIds = Employees.Select(item => item.Id);
                UpdateTree();

                IEnumerable<int> newIds = Employees.Select(item => item.Id);

                List<int> ids = newIds.Except(oldIds).ToList();

                if (ids.Count > 0)
                {
                    employeeEventArgs.Id = ids[0];
                    modelEmplHandlerId.Invoke(this, employeeEventArgs);
                }

            }

        }

        /// <summary>
        /// Получение словаря с необходимыми полями для работы с БД
        /// </summary>
        /// <param name="command">Объект для преобразования</param>
        /// <returns>словарь</returns>
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

        /// <summary>
        /// Получение информации об отделе
        /// </summary>
        /// <param name="name">имя отдела</param>
        /// <returns></returns>
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

        /// <summary>
        /// Сохранение параметров у отдела
        /// </summary>
        /// <param name="command"></param>
        public void SaveChange(DepartmentCommand command)
        {
            try
            {
                bool result = manager.UpdateDepartments(command.Id, GetParam(command));
                departmentEventsArgs.Message = result ? "Сохранено." : "Не сохранилось.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                departmentEventsArgs.Message = String.Format("Ошибка. {0}", e.Message);
            }
            finally
            {
                modelDeptHandlerMessage.Invoke(this, departmentEventsArgs);
                UpdateTree();
            }

        }

        /// <summary>
        /// Сохранение вновь созданного отдела
        /// </summary>
        /// <param name="command"></param>
        public void SaveNew(DepartmentCommand command)
        {
            try
            {
                bool result = manager.InsertDepartments(GetParam(command));
                departmentEventsArgs.Message = result ? "Новый отдел создан." : "Новый отдел не создан.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                departmentEventsArgs.Message = String.Format("Ошибка. {0}", e.Message);
            }
            finally
            {
                modelDeptHandlerMessage.Invoke(this, departmentEventsArgs);

                IEnumerable<string> oldIds = Departments.Select(item => item.Id);
                UpdateTree();

                IEnumerable<string> newIds = Departments.Select(item => item.Id);
                List<string> ids = newIds.Except(oldIds).ToList();
                if (ids.Count > 0)
                {
                    departmentEventsArgs.Id = ids[0];
                    modelDeptHandlerId.Invoke(this, departmentEventsArgs);
                }
            }


        }

        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <param name="command"></param>
        public void Delete(DepartmentCommand command)
        {
            try
            {
                if (command.ParentDepartmentName == null)
                {
                   manager.DeleteDepartmentsAndChildrens(command.Id);
                }
                else
                {
                    Dictionary<string, string> pars = GetParam(command);
                     manager.DeleteDepartmentsAndMoveChildrens(command.Id, pars["ParentDepartmentID"]);
                }

                departmentEventsArgs.Message = "Удалено.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                departmentEventsArgs.Message = String.Format("Ошибка. {0}", e.Message);
            }
            finally
            {
                modelDeptHandlerMessage.Invoke(this, departmentEventsArgs);
                UpdateTree();
            }

        }

        /// <summary>
        /// Получение словаря с необходимыми полями для работы с БД
        /// </summary>
        /// <param name="command">Объект для преобразования</param>
        /// <returns>словарь</returns>
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
