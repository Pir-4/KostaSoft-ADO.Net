using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft.Model
{
    public interface IModelObserver
    {
        void UpdateTree(IModel model, UpdateTreeEventArgs e);

        void DisplayItem(IModel model, UpdateTreeEventArgs e);
    }
}
