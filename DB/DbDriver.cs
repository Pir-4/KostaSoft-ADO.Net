using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DbDriver : IDisposable
    {
        private SqlConnection cn;

        public DbDriver()
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=KARTAVOST-PC\MSSQLSERVER2;Initial Catalog=TestDB;" +
                                  "Integrated Security=SSPI;Pooling=False";
        }

        public void Dispose()
        {
            cn.Close();
            cn.Dispose();
        }

        public void Select()
        {
            try
            {
                cn.Open();

                string query = "Select * From Department";
                SqlCommand command = new SqlCommand(query, cn);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                   string st = String.Format("ID {0}, DepId {1}, Code {2}, Name {3}", dr["ID"], 
                        dr["ParentDepartmentID"], dr["Code"], dr["Name"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                cn.Close();
            }

        }

    }
}
