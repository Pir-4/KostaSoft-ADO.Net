﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace KostaSoft.Model.EventAgrs
{
    public class EmployeeEventArgs : EventArgs
    {
        /// <summary>
        /// Отдел, преназначен для отображения во вьюхе
        /// </summary>
        public Employee DisplayEmp { get; set; }

        /// <summary>
        /// Список отедлов
        /// </summary>
        public List<string> DepNameList { get; set; }
    }
}