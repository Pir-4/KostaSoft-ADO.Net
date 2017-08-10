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
        public TreeItem Root { get; set; }

        public Department DisplayDep { get; set; }

        public Employee DisplyEmp { get; set; }
    }
}
