using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /// <summary>
    /// Общий интерфейс для элементов организации
    /// </summary>
    public interface IOrgItem : IEquatable<IOrgItem>
    {
        string ItemId { get; }

        /// <summary>
        /// ID родительского депортамента
        /// </summary>
        string ParentDepartmentID { get;}

        /// <summary>
        /// Имя элемента
        /// </summary>
        string Name { get;}
    }
}
