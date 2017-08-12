using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft.Model.Observers
{
    public interface IDepartmentObserver
    {
        void UpdateMessage(IModel model, DepartmentEventsArgs e);

        void GetId(IModel model, DepartmentEventsArgs e);
    }
}
