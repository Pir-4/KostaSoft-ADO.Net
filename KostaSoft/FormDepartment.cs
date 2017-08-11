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
using KostaSoft.Model.EventAgrs;

namespace KostaSoft
{
    public partial class FormDepartment : Form
    {
        public FormDepartment()
        {
            InitializeComponent();
        }

        public FormDepartment(IController controller) : this()
        {
            Controller = controller;
        }

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            this.Text = DepEvent.DisplayDep.Name;
            this.textBoxDepName.Text = DepEvent.DisplayDep.Name;
            this.textBoxDepCode.Text = DepEvent.DisplayDep.Code;
            foreach (var item in DepEvent.DepNameList)
                comboBoxDepNames.Items.Add(item);

            comboBoxDepNames.Text = ParentDep;
            this.comboBoxDepNames.Enabled = DepEvent.EnebleListBox;
        }
         
        public DepartmentEventsArgs DepEvent { get; set; }
        public String ParentDep { get; set; }
        private IController Controller { get; set; }


    }
}
