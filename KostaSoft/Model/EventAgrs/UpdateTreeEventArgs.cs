using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace KostaSoft.Model.EventAgrs
{
    /// <summary>
    /// Передача параметров в главную вьюху
    /// </summary>
    public class UpdateTreeEventArgs : EventArgs
    {
        /// <summary>
        /// Ссылка на корень дерева (структкры организации)
        /// </summary>
        public TreeItem Root { get; set; }

        /// <summary>
        /// Список отедлов
        /// </summary>
        public List<string> DepNameList { get; set; }

        /// <summary>
        /// Информационное сообщение
        /// </summary>
        public string Message { get; set; }
    }
}
