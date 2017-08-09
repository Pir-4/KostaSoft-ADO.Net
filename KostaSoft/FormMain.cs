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
using  KostaSoft.Controller;
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
            Controller.GetDepartaments();
        }

        public IController Controller {  get; set; }

        public void UpdateDepartavents(IModel model, UpdateTreeEventArgs e)
        {
            //this.OrgTree.Name = e.Root.Name;
            TreeNode root = new TreeNode(e.Root.Name);
            foreach (var child in e.Root.Children)
            {
                BuildTree(root, child);    
            }
            this.OrgTree.Nodes.Add(root);
            /*foreach (var item in e.Departments)
            {
                TreeNode tr = new TreeNode(item);
                this.OrgTree.Nodes.Add(tr);
            }*/

        }

        private void BuildTree(TreeNode parentNode, TreeItem item)
        {
            if (item.Children.Count == 0)
            {
                parentNode.Nodes.Add(new TreeNode(item.Name));
                return ;
            }

            foreach (var child in item.Children)
            {
                TreeNode newNode = new TreeNode(child.Name);
                BuildTree(newNode, child);
                parentNode.Nodes.Add(newNode);
            }
        }
    }
}
