using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft.Model.Observers
{
    /// <summary>
    /// Интерфейс для работа с формой по обновлению парметров отдела
    /// </summary>
    public interface IDepartmentObserver
    {
        /// <summary>
        /// Обновление информационного сообщения
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        void UpdateMessage(IModel model, DepartmentEventsArgs e);

        /// <summary>
        /// Получение id созданного отдела
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        void GetId(IModel model, DepartmentEventsArgs e);
    }
}
