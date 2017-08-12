using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model.Command;
using KostaSoft.Model.Observers;

namespace KostaSoft.Model
{
    public interface IModel
    {
        void attach(IModelObserver imo);
        void attach(IEmployeeObserver imo);
        void attach(IDepartmentObserver imo);

        void UpdateTree();

        void GetInfoItem(string name);

        void SaveChange(EmployeeCommand command);
        void Delete(int id);
        void SaveNew(EmployeeCommand command);

        void SaveChange(DepartmentCommand command);
        void SaveNew(DepartmentCommand command);
    }
}
