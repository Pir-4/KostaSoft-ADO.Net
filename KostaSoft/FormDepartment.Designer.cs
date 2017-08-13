namespace KostaSoft
{
    partial class FormDepartment
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
            this.comboBoxDepNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDepName = new System.Windows.Forms.TextBox();
            this.labelDepCode = new System.Windows.Forms.Label();
            this.textBoxDepCode = new System.Windows.Forms.TextBox();
            this.labelDep = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDepNames
            // 
            this.comboBoxDepNames.FormattingEnabled = true;
            this.comboBoxDepNames.Location = new System.Drawing.Point(7, 91);
            this.comboBoxDepNames.Name = "comboBoxDepNames";
            this.comboBoxDepNames.Size = new System.Drawing.Size(311, 21);
            this.comboBoxDepNames.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Роительское подразделение";
            // 
            // textBoxDepName
            // 
            this.textBoxDepName.Location = new System.Drawing.Point(7, 42);
            this.textBoxDepName.MaxLength = 50;
            this.textBoxDepName.Name = "textBoxDepName";
            this.textBoxDepName.Size = new System.Drawing.Size(281, 20);
            this.textBoxDepName.TabIndex = 12;
            this.textBoxDepName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDepCode
            // 
            this.labelDepCode.AutoSize = true;
            this.labelDepCode.Location = new System.Drawing.Point(64, 12);
            this.labelDepCode.Name = "labelDepCode";
            this.labelDepCode.Size = new System.Drawing.Size(26, 13);
            this.labelDepCode.TabIndex = 11;
            this.labelDepCode.Text = "Код";
            // 
            // textBoxDepCode
            // 
            this.textBoxDepCode.Location = new System.Drawing.Point(97, 9);
            this.textBoxDepCode.MaxLength = 10;
            this.textBoxDepCode.Name = "textBoxDepCode";
            this.textBoxDepCode.Size = new System.Drawing.Size(61, 20);
            this.textBoxDepCode.TabIndex = 10;
            this.textBoxDepCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDep
            // 
            this.labelDep.AutoSize = true;
            this.labelDep.Location = new System.Drawing.Point(4, 9);
            this.labelDep.Name = "labelDep";
            this.labelDep.Size = new System.Drawing.Size(38, 13);
            this.labelDep.TabIndex = 9;
            this.labelDep.Text = "Отдел";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 126);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSave_MouseClick);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 158);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 13);
            this.labelMessage.TabIndex = 16;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(111, 126);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 17;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDelete_MouseClick);
            // 
            // FormDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 180);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxDepNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDepName);
            this.Controls.Add(this.labelDepCode);
            this.Controls.Add(this.textBoxDepCode);
            this.Controls.Add(this.labelDep);
            this.Name = "FormDepartment";
            this.Text = "Новый отдел";
            this.Load += new System.EventHandler(this.FormDepartment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDepNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDepName;
        private System.Windows.Forms.Label labelDepCode;
        private System.Windows.Forms.TextBox textBoxDepCode;
        private System.Windows.Forms.Label labelDep;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonDelete;
    }
}