using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model;

namespace KostaSoft.Controller
{
    public class Controller : IController
    {
        private IModel model;

        public Controller(IModel model)
        {
            this.model = model;
        }

        public void GetDepartaments()
        {
            model.GetDepartaments();
        }
    }
}
