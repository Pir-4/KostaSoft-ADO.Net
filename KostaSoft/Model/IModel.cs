using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model.Command;

namespace KostaSoft.Model
{
    public interface IModel
    {
        void attach(IModelObserver imo);

        void UpdateTree();

        void GetInfoItem(string name);

        void SaveEmployee(EmployeeCommand command);
        void DeleteEmployee(int id);
        void NewEmployee(EmployeeCommand command);

        void SaveDepartament(DepartmentCommand command);
    }
}
