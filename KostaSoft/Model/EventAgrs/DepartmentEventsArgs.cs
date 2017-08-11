using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace KostaSoft.Model.EventAgrs
{
    public class DepartmentEventsArgs: EventArgs
    {
        /// <summary>
        /// Отдел, преназначен для отображения во вьюхе
        /// </summary>
        public Department DisplayDep { get; set; }

        /// <summary>
        /// Список отедлов
        /// </summary>
        public List<string> DepNameList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool EnebleListBox
        {
            get { return !String.IsNullOrEmpty(DisplayDep.ParentDepartmentID) ; }
        }
    }
}
