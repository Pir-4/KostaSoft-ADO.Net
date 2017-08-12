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
using KostaSoft.Model.EventAgrs;

namespace KostaSoft
{
    public partial class FormDepartment : Form
    {
        private bool isNew = false;

        private DepartmentCommand command = new DepartmentCommand();

        private FormDepartment()
        {
            InitializeComponent();
        }

        public FormDepartment(IController controller, bool isnew = false) : this()
        {
            Controller = controller;
            isNew = isnew;
        }

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                this.textBoxDepCode.Text = DepEvent.DisplayDep.Code;
                foreach (var item in DepNameList)
                    comboBoxDepNames.Items.Add(item);

                comboBoxDepNames.SelectedIndex = 0;
            }
                else
            {
                InitOldDep();
            }
        }

        private void InitOldDep()
        {
            this.Text = DepEvent.DisplayDep.Name;
            command.Id = DepEvent.DisplayDep.Id;

            this.textBoxDepName.Text = DepEvent.DisplayDep.Name;
            this.textBoxDepCode.Text = DepEvent.DisplayDep.Code;
            foreach (var item in DepNameList.Where(item=> !item.Equals(DepEvent.DisplayDep.Name)))
                comboBoxDepNames.Items.Add(item);

            comboBoxDepNames.Text = ParentDep;
            this.comboBoxDepNames.Enabled = DepEvent.EnebleListBox;
        }
        public DepartmentEventsArgs DepEvent { get; set; }

        public String ParentDep { get; set; }

        public List<string> DepNameList { get; set; }

        private IController Controller { get; set; }

        private bool isDateCorrect()
        {

            this.textBoxDepName.BackColor = String.IsNullOrEmpty(this.textBoxDepName.Text)
                ? Color.Maroon : Color.White;


            return !String.IsNullOrEmpty(this.textBoxDepName.Text);
        }

        private void buttonSave_MouseClick(object sender, MouseEventArgs e)
        {
            this.labelMessage.Text = "";

            if (isDateCorrect())
            {
                command.Code = this.textBoxDepCode.Text;
                command.Name = this.textBoxDepName.Text;
                command.ParentDepartmentName = comboBoxDepNames.Enabled
                    ? this.comboBoxDepNames.SelectedItem.ToString()
                    : null;

                if (isNew)
                    ;
                else
                {
                    Controller.SaveDepartament(command);
                }
            }
            else
            {
                this.labelMessage.Text = " Данные не сохранены. Некоторые поля введены неправильно.";
            }
        }
    }
}
