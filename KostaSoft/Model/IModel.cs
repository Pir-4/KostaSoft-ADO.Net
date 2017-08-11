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
    }
}
