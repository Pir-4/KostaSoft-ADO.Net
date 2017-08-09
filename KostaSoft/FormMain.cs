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
            TreeNode root = new TreeNode(e.Root.Name);
            foreach (var child in e.Root.Children)
            {
                root.Nodes.Add(BuildTree(child));    
            }
            this.OrgTree.Nodes.Add(root);

        }

        private TreeNode BuildTree( TreeItem item)
        {
            if (item.Children.Count == 0)
                return new TreeNode(item.Name);
            
            TreeNode newNode = new TreeNode(item.Name);
            foreach (var child in item.Children)
            {
                newNode.Nodes.Add(BuildTree(child));
            }
            return newNode;
        }
    }
}
