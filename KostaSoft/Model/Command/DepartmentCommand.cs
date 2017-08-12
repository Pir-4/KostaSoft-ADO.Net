using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostaSoft.Model.Command
{
    public class DepartmentCommand
    {
        /// <summary>
        /// идентификатор подразделения
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя родительского подразделения
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
