using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KostaSoft.Model;
using KostaSoft.Controller;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft
{
    public partial class FormMain : Form, IModelObserver
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Controller.UpdateTree();
        }

        public IController Controller { get; set; }

        public void UpdateTree(IModel model, UpdateTreeEventArgs e)
        {
            TreeNode root = new TreeNode(e.Root.Name);
            foreach (var child in e.Root.Children)
                root.Nodes.Add(BuildTree(child));

            this.OrgTree.Nodes.Add(root);

        }

        /// <summary>
        /// Посроенени дерева для отображения
        /// </summary>
        /// <param name="item">Элемент входного дерева</param>
        /// <returns>TreeNode</returns>
        private TreeNode BuildTree(TreeItem item)
        {
            if (item.Children.Count == 0)
                return new TreeNode(item.Name);

            TreeNode newNode = new TreeNode(item.Name);
            foreach (var child in item.Children)
                newNode.Nodes.Add(BuildTree(child));

            return newNode;
        }


        public void DepartmentItem(IModel model, DepartmentEventsArgs e)
        {

            this.textBoxDepName.Text = e.DisplayDep.Name;
            this.textBoxDepCode.Text = e.DisplayDep.Code;
            foreach (var item in e.DepNameList)
                comboBoxDepNames.Items.Add(item);

            comboBoxDepNames.Text = e.EnebleListBox ? this.OrgTree.SelectedNode.Parent.Text : "";
            this.comboBoxDepNames.Enabled = e.EnebleListBox;
        }

        public void EmployeeEItem(IModel model, EmployeeEventArgs e)
        {
            
        }

        private void OrgTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Controller.GetInfoItem(this.OrgTree.SelectedNode.Text);
        }


    }
}
