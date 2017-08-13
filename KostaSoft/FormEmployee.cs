using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using KostaSoft.Controller;
using KostaSoft.Model.EventAgrs;
using KostaSoft.Model.Command;
using KostaSoft.Model.Observers;
using KostaSoft.Model;

namespace KostaSoft
{
    public partial class FormEmployee : Form, IEmployeeObserver
    {
        EmployeeCommand command = new EmployeeCommand();
        private const string ERROR_AGE = "-:-";
        private bool _isNew = false;

        private FormEmployee()
        {
            InitializeComponent();
        }

        private bool isNew {
            get { return _isNew; }
            set
            {
                _isNew = value;
                buttonDelete.Enabled = !_isNew;
            }
        }

        public FormEmployee(IController controller, bool isnew = false) : this()
        {
            Controller = controller;
            isNew = isnew;
            Controller.attach(this);
        }
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                foreach (var item in DepNameList)
                    this.comboBoxDepNames.Items.Add(item);

                comboBoxDepNames.SelectedIndex = 0;
            }
            else
            {
                InitOldEmp();
            }
        }

        /// <summary>
        /// Инифиализация полей свойствами сотрудника
        /// </summary>
        private void InitOldEmp()
        {
            Employee emp = EmployeeEvent.DisplayEmp;
            command.Id = emp.Id;

            this.Text = emp.Name;
            this.textBoxSurNameEmp.Text = emp.SurName;
            this.textBoxFirstNameEmp.Text = emp.FirstName;
            this.textBoxPatronymicEmp.Text = emp.Patronymic;

            this.textBoxPosition.Text = emp.Position;
            foreach (var item in DepNameList)
                this.comboBoxDepNames.Items.Add(item);
            comboBoxDepNames.Text = ParentDep;

            this.textBoxDob.Text = emp.DateOfBirth.ToString("dd.MM.yyyy");
            this.textBoxAge.Text = Age(emp.DateOfBirth);

            this.textBoxDocSeries.Text = emp.DocSeries;
            this.textBoxDocNumber.Text = emp.DocNumber;
        }

        public EmployeeEventArgs EmployeeEvent { get; set; }

        public String ParentDep { get; set; }

        public List<string> DepNameList { get; set; }

        private IController Controller { get; set; }

        /// <summary>
        /// Вычесление возроста сотрудника
        /// </summary>
        /// <param name="dateOfBirth">Дата рождения</param>
        /// <returns>возраст сотрудника</returns>
        private string Age(DateTime dateOfBirth)
        {

            DateTime dateNow = DateTime.Now;
            int year = dateNow.Year - dateOfBirth.Year;
            if (dateNow.Month < dateOfBirth.Month ||
                (dateOfBirth.Month == dateNow.Month && dateNow.Day < dateOfBirth.Day))
                year--;
            return year.ToString();


        }

        private void textBoxSurNameEmp_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxFirstNameEmp_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPatronymicEmp_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxDob_TextChanged(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            this.textBoxAge.Text = ERROR_AGE;
            if (DateTime.TryParseExact(this.textBoxDob.Text, new[] { "dd.MM.yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
                this.textBoxAge.Text = Age(date);
        }

        private void textBoxDocSeries_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxDocNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPosition_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDepNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Определение корректности введенных данных
        /// </summary>
        /// <returns></returns>
        private bool isDateCorrect()
        {
            Color good = Color.White;
            Color bad = Color.Salmon;

            this.comboBoxDepNames.BackColor = String.IsNullOrEmpty(this.comboBoxDepNames.SelectedItem.ToString())
                ? bad : good;

            this.textBoxSurNameEmp.BackColor = String.IsNullOrEmpty(this.textBoxSurNameEmp.Text)
                ? bad : good;

            this.textBoxFirstNameEmp.BackColor = String.IsNullOrEmpty(this.textBoxFirstNameEmp.Text)
                ? bad : good;

            this.textBoxPosition.BackColor = String.IsNullOrEmpty(this.textBoxPosition.Text)
                ? bad : good;

            this.textBoxDob.BackColor = this.textBoxAge.Text.Equals(ERROR_AGE)
                ? bad : good;

            return !String.IsNullOrEmpty(this.comboBoxDepNames.SelectedItem.ToString()) &&
                          !String.IsNullOrEmpty(this.textBoxSurNameEmp.Text) &&
                          !String.IsNullOrEmpty(this.textBoxFirstNameEmp.Text) &&
                          !String.IsNullOrEmpty(this.textBoxPosition.Text) && !this.textBoxAge.Text.Equals(ERROR_AGE);

            
        }

        private void buttonSave_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxMessage.Text = "";
            if (isDateCorrect())
            {

                command.SurName = this.textBoxSurNameEmp.Text;
                command.FirstName = this.textBoxFirstNameEmp.Text;
                command.Patronymic = this.textBoxPatronymicEmp.Text;

                command.DocSeries = this.textBoxDocSeries.Text;
                command.DocNumber = this.textBoxDocNumber.Text;

                command.Position = this.textBoxPosition.Text;
                command.DepartmentName = this.comboBoxDepNames.SelectedItem.ToString();

                DateTime date;
                DateTime.TryParseExact(this.textBoxDob.Text, new[] { "dd.MM.yyyy" }, CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out date);
                command.DateOfBirth = date;

                if (isNew)
                {
                    Controller.SaveNew(command);
                    isNew = false;
                }
                else
                    Controller.SaveChange(command);

                this.Text = command.Name;
            }
            else
            {
                this.textBoxMessage.Text = " Данные не сохранены. Некоторые поля введены неправильно.";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить сотрудника?", "Удалить сотрудника",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Controller.Delete(command.Id);
                isNew = true;
            }
        }

        /// <summary>
        /// Обновление информационного сообщения
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void UpdateMassage(IModel model, EmployeeEventArgs e)
        {
            this.textBoxMessage.Text = e.Message;            
        }

        /// <summary>
        /// Получение id для созданного сотрудника
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void GetId(IModel model, EmployeeEventArgs e)
        { 
            command.Id = e.Id;
        }
    }
}
