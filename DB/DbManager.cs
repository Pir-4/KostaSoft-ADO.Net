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

        /// <summary>
        /// Получение списка сотрудников всей организации
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployee()
        {
            DataTable dt = _driver.ExecuteReader("Select * From Empoyee");
            List<Employee> result = new List<Employee>();
            foreach (DataRow row in dt.Rows)
                result.Add(new Employee(row));

            return result;
        }

        /// <summary>
        /// Получение списка сотрудников подразделения
        /// </summary>
        /// <param name="departmentID">идентификатор подразделения</param>
        /// <returns></returns>
        public List<Employee> GetEmployee(string departmentID)
        {
            string query = String.Format("Select * From Empoyee where DepartmentID='{0}'", departmentID);
            DataTable dt = _driver.ExecuteReader(query);
            List<Employee> result = new List<Employee>();
            foreach (DataRow row in dt.Rows)
                result.Add(new Employee(row));

            return result;
        }

        public bool UpdateEmployee(int id, Dictionary<string, string> pars)
        {
            string query = "Update Empoyee Set ";
            IEnumerable<string> sets = pars.Select(kvp => String.Format("{0}='{1}'", kvp.Key, kvp.Value));
            query += String.Join(", ",sets.ToList()) + String.Format(" where ID={0}",id);

            int res = _driver.ExecuteNonQuery(query);
            return res != -1;
        }
    }
}
