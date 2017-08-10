using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using KostaSoft.Model.EventAgrs;

namespace KostaSoft.Model
{

    public class Model : IModel
    {
        delegate void ModelUpdateHandler<IModel>(IModel sender, UpdateTreeEventArgs e);

        UpdateTreeEventArgs updateTreeEventArgs = new UpdateTreeEventArgs();

        private event ModelUpdateHandler<Model> modelHedlerUpdateTree;
        private event ModelUpdateHandler<Model> modelHedlerDisplayItem;

        DbManager manager = new DbManager();
        OrgBuilder builder = new OrgBuilder();

        private List<Department> Departments { get; set; }
        private List<Employee> Employees { get; set; }

        public void attach(IModelObserver imo)
        {
            modelHedlerUpdateTree += new ModelUpdateHandler<Model>(imo.UpdateTree);
            modelHedlerDisplayItem += new ModelUpdateHandler<Model>(imo.DisplayItem);
        }

        public void UpdateTree()
        {
            Departments = manager.GetDepartments();
            Employees = manager.GetEmployee();

            builder.Sotring(Departments.Select(item => (IOrgItem)item).ToList());
            builder.Sotring(Employees.Select(item => (IOrgItem)item).ToList());

            updateTreeEventArgs.Root = builder.Root;
            modelHedlerUpdateTree.Invoke(this, updateTreeEventArgs);
        }

        public void GetInfoItem(string name)
        {
            updateTreeEventArgs.DisplayDep = null;
            updateTreeEventArgs.DisplyEmp = null;

            List<Department> dep = Departments.Where(item => item.Name.Equals(name)).ToList();
            if (dep.Count > 0)
                updateTreeEventArgs.DisplayDep = dep[0];
            else
            {
                List<Employee> emp = Employees.Where(item => item.Name.Equals(name)).ToList();
                if (emp.Count > 0)
                    updateTreeEventArgs.DisplyEmp = emp[0];
            }
            modelHedlerDisplayItem.Invoke(this, updateTreeEventArgs);
        }


    }
}
