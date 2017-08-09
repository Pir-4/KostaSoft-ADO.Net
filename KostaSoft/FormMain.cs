using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KostaSoft.Model;
using  KostaSoft.Controller;

namespace KostaSoft
{
    public partial class FormMain : Form, IModelObserver
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Controller.GetDepartaments();
        }

        public IController Controller {  get; set; }
    }
}
