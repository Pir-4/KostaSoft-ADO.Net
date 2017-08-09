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
using KostaSoft.Model.EventAgrs;

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

        public void UpdateDepartavents(IModel model, UpdateTreeEventArgs e)
        {
            foreach (var item in e.Departments)
            {
                TreeNode tr = new TreeNode(item);
                this.OrgTree.Nodes.Add(tr);
            }
            
        }
    }
}
