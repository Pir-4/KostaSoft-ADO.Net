using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using KostaSoft.Controller;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }
        public FormEmployee(IController controller) : this()
        {
            Controller = controller;
        }
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            Employee emp = EmployeeEvent.DisplayEmp;

            this.Text = emp.Name;
            this.textBoxSurNameEmp.Text = emp.SurName;
            this.textBoxFirstNameEmp.Text = emp.FirstName;
            this.textBoxPatronymicEmp.Text = emp.Patronymic;

            this.textBoxPosition.Text = emp.Position;
            foreach (var item in EmployeeEvent.DepNameList)
                this.comboBoxDepNames.Items.Add(item);
            comboBoxDepNames.Text = ParentDep;

            this.textBoxDob.Text = emp.DateOfBirth.ToString("dd.MM.yyyy");
            this.textBoxAge.Text = Age(emp.DateOfBirth);

            this.textBoxDocSeries.Text = emp.DocSeries;
            this.textBoxDocNumber.Text = emp.DocNumber;
        }

        public EmployeeEventArgs EmployeeEvent { get; set; }
        public String ParentDep { get; set; }
        private IController Controller { get; set; }

        private string Age(DateTime dateOfBirth)
        {

            DateTime dateNow = DateTime.Now;
            int year = dateNow.Year - dateOfBirth.Year;
            if (dateNow.Month < dateOfBirth.Month ||
                (dateOfBirth.Month == dateNow.Month && dateNow.Day < dateOfBirth.Day))
                year--;
            return year.ToString();


        }
    }
}
