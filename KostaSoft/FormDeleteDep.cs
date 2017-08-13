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
using KostaSoft.Model.Command;

namespace KostaSoft
{
    public partial class FormDeleteDep : Form
    {
        private Action isDel;

        private FormDeleteDep()
        {
            InitializeComponent();
        }

        public FormDeleteDep(IController controller, List<string> deps, DepartmentCommand command, Action del) : this()
        {
            DepNameList = deps;
            Controller = controller;
            isDel = del;
            Command = command;
        }

        private void FormDeleteDep_Load(object sender, EventArgs e)
        {
            foreach (var item in DepNameList)
                this.comboBoxDepNames.Items.Add(item);

            comboBoxDepNames.SelectedIndex = 0;
        }

        private List<string> DepNameList { get; set; }
        private IController Controller { get; set; }
        private DepartmentCommand Command { get; set; }


        private void buttonDelAll_MouseClick(object sender, MouseEventArgs e)
        {
            Command.ParentDepartmentName = null;
            Controller.Delete(Command);
            isDel();
            this.Close();
        }

        private void buttonDelAndMove_MouseClick(object sender, MouseEventArgs e)
        {
            Command.ParentDepartmentName = comboBoxDepNames.SelectedItem.ToString();
            Controller.Delete(Command);
            isDel();
            this.Close();
        }
    }
}
