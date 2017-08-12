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

        public void attach(IDepartmentObserver imo) => model.attach(imo);

        public void UpdateTree() => model.UpdateTree();

        public void GetInfoItem(string name) => model.GetInfoItem(name);

        #region Employee
        public void SaveChange(EmployeeCommand command) => model.SaveChange(command);

        public void DeleteEmployee(int id) => model.Delete(id);

        public void SaveNew(EmployeeCommand command) => model.SaveNew(command);

        #endregion

        #region Departament

        public void SaveChange(DepartmentCommand command) => model.SaveChange(command);

        public void SaveNew(DepartmentCommand command) => model.SaveNew(command);

        #endregion

    }
}
