using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /// <summary>
    /// Подражделение
    /// </summary>
    public class Department
    {
        public Department()
        {

        }

        public Department(DataRow row)
        {
            Id = row["ID"].ToString();
            ParentDepartmentID = row["ParentDepartmentID"].ToString();
            Code = row["Code"].ToString();
            Name = row["Name"].ToString();
        }

        /// <summary>
        /// идентификатор подразделения
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// идентификатор родительского подразделения
        /// </summary>
        public string ParentDepartmentID { get; set; }

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
