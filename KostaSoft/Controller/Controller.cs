using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model;
using KostaSoft.Model.Command;

namespace KostaSoft.Controller
{
    public class Controller : IController
    {
        private IModel model;

        public Controller(IModel model)
        {
            this.model = model;
        }

        public void UpdateTree() => model.UpdateTree();

        public void GetInfoItem(string name) => model.GetInfoItem(name);

        public void SaveEmployee(EmployeeCommand command) => model.SaveEmployee(command);
    }
}
