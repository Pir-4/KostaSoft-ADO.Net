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

        private event ModelUpdateHandler<Model> modelHedlerUpdateDepartament;

       DbManager manager = new DbManager();
        public void attach(IModelObserver imo)
        {
            modelHedlerUpdateDepartament += new ModelUpdateHandler<Model>(imo.UpdateDepartavents);
        }

        public void GetDepartaments()
        {
            updateTreeEventArgs.Departments = manager.GetDepartments().Select(item => item.Name).ToList();
            modelHedlerUpdateDepartament.Invoke(this,updateTreeEventArgs);
        }
    }
}
