using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model;
using KostaSoft.Model.Command;
using KostaSoft.Model.Observers;

namespace KostaSoft.Controller
{
    public class Controller : IController
    {
        private IModel model;

        public Controller(IModel model)
        {
            this.model = model;
        }

        public void attach(IEmployeeObserver imo) => model.attach(imo);

        public void UpdateTree() => model.UpdateTree();

        public void GetInfoItem(string name) => model.GetInfoItem(name);

        #region Employee
        public void SaveEmployee(EmployeeCommand command) => model.SaveEmployee(command);

        public void DeleteEmployee(int id) => model.DeleteEmployee(id);

        public void NewEmployee(EmployeeCommand command) => model.NewEmployee(command);

        #endregion

        #region Departament

        public void SaveDepartament(DepartmentCommand command) => model.SaveDepartament(command);

        public void NewDepartment(DepartmentCommand command) => model.NewDepartment(command);

        #endregion

    }
}
