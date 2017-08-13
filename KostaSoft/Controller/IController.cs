using KostaSoft.Model.Command;
using KostaSoft.Model.Observers;

namespace KostaSoft.Controller
{
    public interface IController
    {
        void attach(IEmployeeObserver imo);
        void attach(IDepartmentObserver imo);

        void UpdateTree();
        void GetInfoItem(string name);

        void SaveChange(EmployeeCommand command);
        void Delete(int id);
        void SaveNew(EmployeeCommand command);

        void SaveChange(DepartmentCommand command);
        void SaveNew(DepartmentCommand command);
        void Delete(DepartmentCommand command);
    }
}