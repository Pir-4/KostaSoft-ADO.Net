using KostaSoft.Model.Command;

namespace KostaSoft.Controller
{
    public interface IController
    {
        void UpdateTree();
        void GetInfoItem(string name);

        void SaveEmployee(EmployeeCommand command);
        void DeleteEmployee(int id);
        void NewEmployee(EmployeeCommand command);
    }
}