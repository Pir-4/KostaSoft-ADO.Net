using KostaSoft.Model.Command;
using KostaSoft.Model.Observers;

namespace KostaSoft.Controller
{
    public interface IController
    {
        void attach(IEmployeeObserver imo);

        void UpdateTree();
        void GetInfoItem(string name);

        void SaveEmployee(EmployeeCommand command);
        void DeleteEmployee(int id);
        void NewEmployee(EmployeeCommand command);

        void SaveDepartament(DepartmentCommand command);
        void NewDepartment(DepartmentCommand command);
    }
}