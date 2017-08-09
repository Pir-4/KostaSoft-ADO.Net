using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostaSoft.Model
{
    public interface IModel
    {
        void attach(IModelObserver imo);

        void GetDepartaments();
    }
}
