using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DbManager
    {
        private DbDriver _driver = new DbDriver();

        public List<Department> GetDepartments()
        {
            DataTable dt = _driver.ExecuteReader("Select * From Department");
            List <Department> result = new List<Department>();
            foreach (DataRow row in dt.Rows)
                result.Add(new Department(row));
            return result;
        }
    }
}
