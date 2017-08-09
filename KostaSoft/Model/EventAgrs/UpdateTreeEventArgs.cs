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
        public List<string> Departments { get; set; }
    }
}
