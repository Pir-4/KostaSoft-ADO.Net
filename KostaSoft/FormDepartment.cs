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
using KostaSoft.Model;
using KostaSoft.Model.Command;
using KostaSoft.Model.EventAgrs;
using KostaSoft.Model.Observers;

namespace KostaSoft
{
    public partial class FormDepartment : Form, IDepartmentObserver
    {
        private bool _isNew = false;

        private DepartmentCommand command = new DepartmentCommand();

        private FormDepartment()
        {
            InitializeComponent();
        }

        public FormDepartment(IController controller, bool isnew = false) : this()
        {
            Controller = controller;
            isNew = isnew;
            Controller.attach(this);
        }

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                foreach (var item in DepNameList)
                    comboBoxDepNames.Items.Add(item);

                comboBoxDepNames.SelectedIndex = 0;
            }
            else
                InitOldDep();

        }

        private bool isNew
        {
            get { return _isNew; }
            set
            {
                _isNew = value;
                buttonDelete.Enabled = !_isNew;
                if (!this.comboBoxDepNames.Enabled)
                    buttonDelete.Enabled = false;
            }
        }
        /// <summary>
        /// Инициализация полей свойствами отдела
        /// </summary>
        private void InitOldDep()
        {
            this.Text = DepEvent.DisplayDep.Name;
            command.Id = DepEvent.DisplayDep.Id;

            this.textBoxDepName.Text = DepEvent.DisplayDep.Name;
            this.textBoxDepCode.Text = DepEvent.DisplayDep.Code;
            foreach (var item in DepNameList.Where(item => !item.Equals(DepEvent.DisplayDep.Name)))
                comboBoxDepNames.Items.Add(item);

            comboBoxDepNames.Text = ParentDep;
            this.comboBoxDepNames.Enabled = buttonDelete.Enabled = DepEvent.EnebleListBox;
        }
        public DepartmentEventsArgs DepEvent { get; set; }

        public String ParentDep { get; set; }

        public List<string> DepNameList { get; set; }

        private IController Controller { get; set; }

        /// <summary>
        /// Определение корректности введенных данных
        /// </summary>
        /// <returns></returns>
        private bool isDateCorrect()
        {

            this.textBoxDepName.BackColor = String.IsNullOrEmpty(this.textBoxDepName.Text)
                ? Color.Maroon : Color.White;


            return !String.IsNullOrEmpty(this.textBoxDepName.Text);
        }

        private void buttonSave_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxMessage.Text = "";

            if (isDateCorrect())
            {
                command.Code = this.textBoxDepCode.Text;
                command.Name = this.textBoxDepName.Text;
                command.ParentDepartmentName = comboBoxDepNames.Enabled
                    ? this.comboBoxDepNames.SelectedItem.ToString()
                    : null;

                if (isNew)
                {
                    Controller.SaveNew(command);
                    isNew = false;
                }
                else
                {
                    Controller.SaveChange(command);
                }
            }
            else
            {
                this.textBoxMessage.Text = " Данные не сохранены. Некоторые поля введены неправильно.";
            }
        }

        /// <summary>
        /// Обновление информационного сообщение
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void UpdateMessage(IModel model, DepartmentEventsArgs e)
        {
            textBoxMessage.Text = e.Message;
        }

        /// <summary>
        /// Получение id для созданого отдела
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void GetId(IModel model, DepartmentEventsArgs e)
        {
            command.Id = e.Id;
        }
 
        private void buttonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            FormDeleteDep from =new FormDeleteDep(Controller, DepNameList, command, () => isNew = true);

            from.Show();
        }
    }
}
