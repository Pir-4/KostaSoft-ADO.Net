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
    public class Department : IOrgItem
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

        public string ItemId
        {
            get { return Id; }
        }

        public bool Equals(IOrgItem other)
        {
            if (other is Department)
            {
                Department otherDepartment = other as Department;

                return Id.Equals(otherDepartment.Id) && ParentDepartmentID.Equals(otherDepartment.ParentDepartmentID) &&
                       Name.Equals(otherDepartment.Name) &&
                       Code.Equals(otherDepartment.Code);
                }
            return false;
        }
    }
}
