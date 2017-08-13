using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace KostaSoft.Model.EventAgrs
{
    /// <summary>
    /// Передача парметров сотрудника из модеи во вьюху
    /// </summary>
    public class EmployeeEventArgs : EventArgs
    {
        /// <summary>
        /// Отдел, преназначен для отображения во вьюхе
        /// </summary>
        public Employee DisplayEmp { get; set; }

        /// <summary>
        /// Идентификатор созданого сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Информационное сообщение
        /// </summary>
        public string Message { get; set; }
    }
}
