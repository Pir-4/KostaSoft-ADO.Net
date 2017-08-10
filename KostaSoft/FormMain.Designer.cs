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
            this.labelDep = new System.Windows.Forms.Label();
            this.textBoxDepCode = new System.Windows.Forms.TextBox();
            this.labelDepCode = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // labelDep
            // 
            this.labelDep.AutoSize = true;
            this.labelDep.Location = new System.Drawing.Point(289, 13);
            this.labelDep.Name = "labelDep";
            this.labelDep.Size = new System.Drawing.Size(38, 13);
            this.labelDep.TabIndex = 1;
            this.labelDep.Text = "Отдел";
            // 
            // textBoxDepCode
            // 
            this.textBoxDepCode.Location = new System.Drawing.Point(334, 42);
            this.textBoxDepCode.Name = "textBoxDepCode";
            this.textBoxDepCode.Size = new System.Drawing.Size(120, 20);
            this.textBoxDepCode.TabIndex = 2;
            // 
            // labelDepCode
            // 
            this.labelDepCode.AutoSize = true;
            this.labelDepCode.Location = new System.Drawing.Point(301, 45);
            this.labelDepCode.Name = "labelDepCode";
            this.labelDepCode.Size = new System.Drawing.Size(26, 13);
            this.labelDepCode.TabIndex = 3;
            this.labelDepCode.Text = "Код";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(334, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(304, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 30);
            this.listBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Роительское подразделение";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(774, 255);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelDepCode);
            this.Controls.Add(this.textBoxDepCode);
            this.Controls.Add(this.labelDep);
            this.Controls.Add(this.OrgTree);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView OrgTree;
        private System.Windows.Forms.Label labelDep;
        private System.Windows.Forms.TextBox textBoxDepCode;
        private System.Windows.Forms.Label labelDepCode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}

