using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace KostaSoft.Model.EventAgrs
{
    public class UpdateTreeEventArgs : EventArgs
    {
        /// <summary>
        /// Ссылка на корень дерева (структкры организации)
        /// </summary>
        public TreeItem Root { get; set; }

        public Employee DisplyEmp { get; set; }
    }
}
