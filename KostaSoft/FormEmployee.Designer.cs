﻿namespace KostaSoft
{
    partial class FormEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPatronymicEmp = new System.Windows.Forms.TextBox();
            this.labelPatronymicEmp = new System.Windows.Forms.Label();
            this.textBoxFirstNameEmp = new System.Windows.Forms.TextBox();
            this.labelFirstNameEmp = new System.Windows.Forms.Label();
            this.textBoxSurNameEmp = new System.Windows.Forms.TextBox();
            this.labelSurNameEmp = new System.Windows.Forms.Label();
            this.textBoxDob = new System.Windows.Forms.TextBox();
            this.labelDob = new System.Windows.Forms.Label();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.labelAge = new System.Windows.Forms.Label();
            this.textBoxDocSeries = new System.Windows.Forms.TextBox();
            this.labelDocSeries = new System.Windows.Forms.Label();
            this.textBoxDocNumber = new System.Windows.Forms.TextBox();
            this.labelDocNumber = new System.Windows.Forms.Label();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelDoc = new System.Windows.Forms.Label();
            this.labelDep = new System.Windows.Forms.Label();
            this.comboBoxDepNames = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxPatronymicEmp
            // 
            this.textBoxPatronymicEmp.Location = new System.Drawing.Point(80, 86);
            this.textBoxPatronymicEmp.MaxLength = 50;
            this.textBoxPatronymicEmp.Name = "textBoxPatronymicEmp";
            this.textBoxPatronymicEmp.Size = new System.Drawing.Size(104, 20);
            this.textBoxPatronymicEmp.TabIndex = 20;
            this.textBoxPatronymicEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPatronymicEmp.TextChanged += new System.EventHandler(this.textBoxPatronymicEmp_TextChanged);
            // 
            // labelPatronymicEmp
            // 
            this.labelPatronymicEmp.AutoSize = true;
            this.labelPatronymicEmp.Location = new System.Drawing.Point(19, 84);
            this.labelPatronymicEmp.Name = "labelPatronymicEmp";
            this.labelPatronymicEmp.Size = new System.Drawing.Size(54, 13);
            this.labelPatronymicEmp.TabIndex = 19;
            this.labelPatronymicEmp.Text = "Отчество";
            // 
            // textBoxFirstNameEmp
            // 
            this.textBoxFirstNameEmp.Location = new System.Drawing.Point(81, 53);
            this.textBoxFirstNameEmp.MaxLength = 50;
            this.textBoxFirstNameEmp.Name = "textBoxFirstNameEmp";
            this.textBoxFirstNameEmp.Size = new System.Drawing.Size(104, 20);
            this.textBoxFirstNameEmp.TabIndex = 18;
            this.textBoxFirstNameEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFirstNameEmp.TextChanged += new System.EventHandler(this.textBoxFirstNameEmp_TextChanged);
            // 
            // labelFirstNameEmp
            // 
            this.labelFirstNameEmp.AutoSize = true;
            this.labelFirstNameEmp.Location = new System.Drawing.Point(19, 56);
            this.labelFirstNameEmp.Name = "labelFirstNameEmp";
            this.labelFirstNameEmp.Size = new System.Drawing.Size(29, 13);
            this.labelFirstNameEmp.TabIndex = 17;
            this.labelFirstNameEmp.Text = "Имя";
            // 
            // textBoxSurNameEmp
            // 
            this.textBoxSurNameEmp.Location = new System.Drawing.Point(80, 23);
            this.textBoxSurNameEmp.MaxLength = 50;
            this.textBoxSurNameEmp.Name = "textBoxSurNameEmp";
            this.textBoxSurNameEmp.Size = new System.Drawing.Size(104, 20);
            this.textBoxSurNameEmp.TabIndex = 16;
            this.textBoxSurNameEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSurNameEmp.TextChanged += new System.EventHandler(this.textBoxSurNameEmp_TextChanged);
            // 
            // labelSurNameEmp
            // 
            this.labelSurNameEmp.AutoSize = true;
            this.labelSurNameEmp.Location = new System.Drawing.Point(18, 26);
            this.labelSurNameEmp.Name = "labelSurNameEmp";
            this.labelSurNameEmp.Size = new System.Drawing.Size(56, 13);
            this.labelSurNameEmp.TabIndex = 15;
            this.labelSurNameEmp.Text = "Фамилия";
            // 
            // textBoxDob
            // 
            this.textBoxDob.Location = new System.Drawing.Point(111, 126);
            this.textBoxDob.Name = "textBoxDob";
            this.textBoxDob.Size = new System.Drawing.Size(73, 20);
            this.textBoxDob.TabIndex = 22;
            this.textBoxDob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDob.TextChanged += new System.EventHandler(this.textBoxDob_TextChanged);
            // 
            // labelDob
            // 
            this.labelDob.AutoSize = true;
            this.labelDob.Location = new System.Drawing.Point(19, 129);
            this.labelDob.Name = "labelDob";
            this.labelDob.Size = new System.Drawing.Size(86, 13);
            this.labelDob.TabIndex = 21;
            this.labelDob.Text = "Дата рождения";
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(275, 122);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.ReadOnly = true;
            this.textBoxAge.Size = new System.Drawing.Size(32, 20);
            this.textBoxAge.TabIndex = 24;
            this.textBoxAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(204, 126);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(49, 13);
            this.labelAge.TabIndex = 23;
            this.labelAge.Text = "Возраст";
            // 
            // textBoxDocSeries
            // 
            this.textBoxDocSeries.Location = new System.Drawing.Point(80, 186);
            this.textBoxDocSeries.MaxLength = 4;
            this.textBoxDocSeries.Name = "textBoxDocSeries";
            this.textBoxDocSeries.Size = new System.Drawing.Size(51, 20);
            this.textBoxDocSeries.TabIndex = 26;
            this.textBoxDocSeries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDocSeries.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDocSeries_KeyPress);
            // 
            // labelDocSeries
            // 
            this.labelDocSeries.AutoSize = true;
            this.labelDocSeries.Location = new System.Drawing.Point(19, 186);
            this.labelDocSeries.Name = "labelDocSeries";
            this.labelDocSeries.Size = new System.Drawing.Size(38, 13);
            this.labelDocSeries.TabIndex = 25;
            this.labelDocSeries.Text = "Серия";
            // 
            // textBoxDocNumber
            // 
            this.textBoxDocNumber.Location = new System.Drawing.Point(80, 212);
            this.textBoxDocNumber.MaxLength = 6;
            this.textBoxDocNumber.Name = "textBoxDocNumber";
            this.textBoxDocNumber.Size = new System.Drawing.Size(51, 20);
            this.textBoxDocNumber.TabIndex = 28;
            this.textBoxDocNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDocNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDocNumber_KeyPress);
            // 
            // labelDocNumber
            // 
            this.labelDocNumber.AutoSize = true;
            this.labelDocNumber.Location = new System.Drawing.Point(19, 212);
            this.labelDocNumber.Name = "labelDocNumber";
            this.labelDocNumber.Size = new System.Drawing.Size(41, 13);
            this.labelDocNumber.TabIndex = 27;
            this.labelDocNumber.Text = "Номер";
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Location = new System.Drawing.Point(275, 23);
            this.textBoxPosition.MaxLength = 50;
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(193, 20);
            this.textBoxPosition.TabIndex = 30;
            this.textBoxPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPosition.TextChanged += new System.EventHandler(this.textBoxPosition_TextChanged);
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(204, 26);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(65, 13);
            this.labelPosition.TabIndex = 29;
            this.labelPosition.Text = "Должность";
            // 
            // labelDoc
            // 
            this.labelDoc.AutoSize = true;
            this.labelDoc.Location = new System.Drawing.Point(19, 158);
            this.labelDoc.Name = "labelDoc";
            this.labelDoc.Size = new System.Drawing.Size(58, 13);
            this.labelDoc.TabIndex = 31;
            this.labelDoc.Text = "Документ";
            // 
            // labelDep
            // 
            this.labelDep.AutoSize = true;
            this.labelDep.Location = new System.Drawing.Point(204, 52);
            this.labelDep.Name = "labelDep";
            this.labelDep.Size = new System.Drawing.Size(38, 13);
            this.labelDep.TabIndex = 32;
            this.labelDep.Text = "Отдел";
            // 
            // comboBoxDepNames
            // 
            this.comboBoxDepNames.FormattingEnabled = true;
            this.comboBoxDepNames.Location = new System.Drawing.Point(275, 52);
            this.comboBoxDepNames.Name = "comboBoxDepNames";
            this.comboBoxDepNames.Size = new System.Drawing.Size(290, 21);
            this.comboBoxDepNames.TabIndex = 33;
            this.comboBoxDepNames.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepNames_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(178, 183);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 34;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSave_MouseClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(275, 184);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 36;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMessage.Location = new System.Drawing.Point(178, 212);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new System.Drawing.Size(387, 38);
            this.textBoxMessage.TabIndex = 37;
            // 
            // FormEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 262);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxDepNames);
            this.Controls.Add(this.labelDep);
            this.Controls.Add(this.labelDoc);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.textBoxDocNumber);
            this.Controls.Add(this.labelDocNumber);
            this.Controls.Add(this.textBoxDocSeries);
            this.Controls.Add(this.labelDocSeries);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.textBoxDob);
            this.Controls.Add(this.labelDob);
            this.Controls.Add(this.textBoxPatronymicEmp);
            this.Controls.Add(this.labelPatronymicEmp);
            this.Controls.Add(this.textBoxFirstNameEmp);
            this.Controls.Add(this.labelFirstNameEmp);
            this.Controls.Add(this.textBoxSurNameEmp);
            this.Controls.Add(this.labelSurNameEmp);
            this.Name = "FormEmployee";
            this.Text = "Новый сотрудник";
            this.Load += new System.EventHandler(this.FormEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPatronymicEmp;
        private System.Windows.Forms.Label labelPatronymicEmp;
        private System.Windows.Forms.TextBox textBoxFirstNameEmp;
        private System.Windows.Forms.Label labelFirstNameEmp;
        private System.Windows.Forms.TextBox textBoxSurNameEmp;
        private System.Windows.Forms.Label labelSurNameEmp;
        private System.Windows.Forms.TextBox textBoxDob;
        private System.Windows.Forms.Label labelDob;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.TextBox textBoxDocSeries;
        private System.Windows.Forms.Label labelDocSeries;
        private System.Windows.Forms.TextBox textBoxDocNumber;
        private System.Windows.Forms.Label labelDocNumber;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelDoc;
        private System.Windows.Forms.Label labelDep;
        private System.Windows.Forms.ComboBox comboBoxDepNames;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxMessage;
    }
}