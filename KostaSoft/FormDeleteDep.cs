using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KostaSoft.Controller;

namespace KostaSoft
{
    public partial class FormDeleteDep : Form
    {
        private Action isDel;

        private FormDeleteDep()
        {
            InitializeComponent();
        }

        public FormDeleteDep(IController controller, List<string> deps, Action del) : this()
        {
            DepNameList = deps;
            Controller = controller;
            isDel = del;
        }

        private void FormDeleteDep_Load(object sender, EventArgs e)
        {
            foreach (var item in DepNameList)
                this.comboBoxDepNames.Items.Add(item);

            comboBoxDepNames.SelectedIndex = 0;
        }

        private List<string> DepNameList { get; set; }
        private IController Controller { get; set; }


        private void buttonDelAll_MouseClick(object sender, MouseEventArgs e)
        {
            isDel();
        }
    }
}
