using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KostaSoft.Model;
using KostaSoft.Controller;

namespace KostaSoft
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormMain view = new FormMain();
            IModel model = new Model.Model();
            model.attach(view);
            view.Controller = new Controller.Controller(model);

            Application.Run(view);
        }
    }
}
