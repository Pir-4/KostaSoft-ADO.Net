using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostaSoft.Model.Command
{
    public class EmployeeCommand
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя подразделения
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Серия документа
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// должность
        /// </summary>
        public string Position { get; set; }
    }
}
