using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft.Model.Observers
{
    /// <summary>
    /// Интрефейс для передачи параметров общей форме
    /// </summary>
    public interface IModelObserver
    {
        /// <summary>
        /// Обновление структуры организации
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        void UpdateTree(IModel model, UpdateTreeEventArgs e);

        /// <summary>
        /// Возрат информации о отделе
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        void DepartmentItem(IModel model, DepartmentEventsArgs e);

        /// <summary>
        /// Возрат информации о сотруднике
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        void EmployeeEItem(IModel model, EmployeeEventArgs e);

        /// <summary>
        /// Обновляет информационное сообщение
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        void UpdateMessage(IModel model, UpdateTreeEventArgs e);
    }
}
