using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /// <summary>
    /// Производит непосредственные запросы к БД
    /// </summary>
    public class DbDriver : IDisposable
    {
        private SqlConnection connect;

        public DbDriver()
        {
            connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=KARTAVOST-PC\MSSQLSERVER2;Initial Catalog=TestDB;" +
                                  "Integrated Security=SSPI;Pooling=False";
        }

        /// <summary>
        /// Извлечение данных из БД
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns>результат</returns>
        public DataTable ExecuteReader(string query)
        {
            try
            {
                connect.Open();

                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader dr = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// Запрос не требующий возрата значений из БД
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns>количество измененных строк</returns>
        public int ExecuteNonQuery(string query)
        {
            try
            {
                connect.Open();

                SqlCommand command = new SqlCommand(query, connect);            
                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// Выполнение транзакции в БД
        /// </summary>
        /// <param name="querys">Список запросов</param>
        public void Transaction(List<string> querys)
        {
            List<SqlCommand> commands = querys.Select(query => new SqlCommand(query, connect)).ToList();
            SqlTransaction tx = null;
            try
            {
                connect.Open();
                tx = connect.BeginTransaction();

                //Включение команд втранзакцию
                foreach (var command in commands)
                    command.Transaction = tx;

                //Выполнение команд
                foreach (var command in commands)
                    command.ExecuteNonQuery();

                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
                Console.WriteLine(e);
                throw e;
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// Уничтожение объекта
        /// </summary>
        public void Dispose()
        {
            connect.Dispose();
        }

    }
}
