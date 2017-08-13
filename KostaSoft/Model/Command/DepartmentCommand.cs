using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostaSoft.Model.Command
{
    /// <summary>
    /// Передача парметров отдела из формы в модель
    /// </summary>
    public class DepartmentCommand
    {
        /// <summary>
        /// идентификатор отдела
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя родительского отдела
        /// </summary>
        public string ParentDepartmentName { get; set; }

        /// <summary>
        /// мнемокод
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// наименование
        /// </summary>
        public string Name { get; set; }
    }
}
