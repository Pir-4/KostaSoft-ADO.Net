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
using KostaSoft.Model.Observers;

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
            this.OrgTree.Nodes.Clear();
            DepartementNames = e.DepNameList;

            TreeNode root = new TreeNode(e.Root.Name);
            foreach (var child in e.Root.Children)
                root.Nodes.Add(BuildTree(child));

            this.OrgTree.Nodes.Add(root);
            this.Text = root.Text;
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
            FormDepartment form = new FormDepartment(Controller)
            {
                DepEvent = e,
                ParentDep = e.EnebleListBox ? this.OrgTree.SelectedNode.Parent.Text : "",
                DepNameList = DepartementNames
            };
            form.Show();

        }

        public void EmployeeEItem(IModel model, EmployeeEventArgs e)
        {
            FormEmployee form = new FormEmployee(Controller)
            {
                EmployeeEvent = e,
                ParentDep = this.OrgTree.SelectedNode.Parent.Text,
                DepNameList = DepartementNames,
            };
            form.Show();
        }

        private List<string> DepartementNames { get; set; }

        private void OrgTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            Controller.GetInfoItem(this.OrgTree.SelectedNode.Text);
        }

        private void buttonNewEmp_Click(object sender, EventArgs e)
        {
            FormEmployee from = new FormEmployee(Controller, true)
            {
                DepNameList = DepartementNames
            };
            from.Show();
        }

        private void buttonNewDep_MouseClick(object sender, MouseEventArgs e)
        {
            FormDepartment from = new FormDepartment(Controller, true)
            {
                DepNameList = DepartementNames,
            };
            from.Show();
        }
    }
}
