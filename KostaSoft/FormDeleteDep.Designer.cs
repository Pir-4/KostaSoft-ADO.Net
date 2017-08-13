namespace KostaSoft
{
    partial class FormDeleteDep
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
            this.buttonDelAll = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonDelAndMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDepNames
            // 
            this.comboBoxDepNames.FormattingEnabled = true;
            this.comboBoxDepNames.Location = new System.Drawing.Point(12, 81);
            this.comboBoxDepNames.Name = "comboBoxDepNames";
            this.comboBoxDepNames.Size = new System.Drawing.Size(311, 21);
            this.comboBoxDepNames.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Новый отдел";
            // 
            // buttonDelAll
            // 
            this.buttonDelAll.Location = new System.Drawing.Point(12, 108);
            this.buttonDelAll.Name = "buttonDelAll";
            this.buttonDelAll.Size = new System.Drawing.Size(75, 42);
            this.buttonDelAll.TabIndex = 17;
            this.buttonDelAll.Text = "Удалить все";
            this.buttonDelAll.UseVisualStyleBackColor = true;
            this.buttonDelAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDelAll_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(318, 53);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "Если вы не хотите удалять все под отделы и сотрудников, то выберите новый отдел, " +
    "куда их переместить и нажмите \"Удалить и переместить\".";
            // 
            // buttonDelAndMove
            // 
            this.buttonDelAndMove.Location = new System.Drawing.Point(93, 108);
            this.buttonDelAndMove.Name = "buttonDelAndMove";
            this.buttonDelAndMove.Size = new System.Drawing.Size(86, 42);
            this.buttonDelAndMove.TabIndex = 20;
            this.buttonDelAndMove.Text = "Удалить и перместить";
            this.buttonDelAndMove.UseVisualStyleBackColor = true;
            this.buttonDelAndMove.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDelAndMove_MouseClick);
            // 
            // FormDeleteDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 162);
            this.Controls.Add(this.buttonDelAndMove);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDelAll);
            this.Controls.Add(this.comboBoxDepNames);
            this.Controls.Add(this.label1);
            this.Name = "FormDeleteDep";
            this.Text = "Удаление";
            this.Load += new System.EventHandler(this.FormDeleteDep_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDepNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDelAll;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonDelAndMove;
    }
}