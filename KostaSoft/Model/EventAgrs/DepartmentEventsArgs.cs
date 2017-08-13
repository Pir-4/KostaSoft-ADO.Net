using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace KostaSoft.Model.EventAgrs
{
    /// <summary>
    /// Передача параметров из модели во вьюху
    /// </summary>
    public class DepartmentEventsArgs: EventArgs
    {
        /// <summary>
        /// Отдел, преназначен для отображения во вьюхе
        /// </summary>
        public Department DisplayDep { get; set; }

        /// <summary>
        /// Определяет является ли объект самым верхним.
        /// </summary>
        public bool EnebleListBox
        {
            get { return !String.IsNullOrEmpty(DisplayDep.ParentDepartmentID) ; }
        }

        /// <summary>
        /// Идентификатор созданого отдела
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Информационное сообщение
        /// </summary>
        public string Message { get; set; }
    }
}
