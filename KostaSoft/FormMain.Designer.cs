namespace KostaSoft
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OrgTree = new System.Windows.Forms.TreeView();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonNewEmp = new System.Windows.Forms.Button();
            this.buttonNewDep = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OrgTree
            // 
            this.OrgTree.Location = new System.Drawing.Point(3, 2);
            this.OrgTree.Name = "OrgTree";
            this.OrgTree.Size = new System.Drawing.Size(279, 223);
            this.OrgTree.TabIndex = 0;
            this.OrgTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OrgTree_AfterSelect);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(292, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 15;
            this.buttonOpen.Text = "Открыть";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonNewEmp
            // 
            this.buttonNewEmp.Location = new System.Drawing.Point(292, 54);
            this.buttonNewEmp.Name = "buttonNewEmp";
            this.buttonNewEmp.Size = new System.Drawing.Size(75, 35);
            this.buttonNewEmp.TabIndex = 16;
            this.buttonNewEmp.Text = "Новый сотрудник";
            this.buttonNewEmp.UseVisualStyleBackColor = true;
            this.buttonNewEmp.Click += new System.EventHandler(this.buttonNewEmp_Click);
            // 
            // buttonNewDep
            // 
            this.buttonNewDep.Location = new System.Drawing.Point(292, 95);
            this.buttonNewDep.Name = "buttonNewDep";
            this.buttonNewDep.Size = new System.Drawing.Size(75, 35);
            this.buttonNewDep.TabIndex = 17;
            this.buttonNewDep.Text = "Новый отдел";
            this.buttonNewDep.UseVisualStyleBackColor = true;
            this.buttonNewDep.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonNewDep_MouseClick);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMessage.Location = new System.Drawing.Point(3, 231);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new System.Drawing.Size(372, 41);
            this.textBoxMessage.TabIndex = 18;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(377, 276);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonNewDep);
            this.Controls.Add(this.buttonNewEmp);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.OrgTree);
            this.Name = "FormMain";
            this.Text = "Фирма";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView OrgTree;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonNewEmp;
        private System.Windows.Forms.Button buttonNewDep;
        private System.Windows.Forms.TextBox textBoxMessage;
    }
}

