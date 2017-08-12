using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft.Model.Observers
{
    public interface IEmployeeObserver
    {
        /// <summary>
        /// Обновляет сообщение о результате дейcndbz
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        void UpdateMassage(IModel model, EmployeeEventArgs e);

        /// <summary>
        /// Возращает Id вновь созданого элемента
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        void GetId(IModel model, EmployeeEventArgs e);
    }
}
