using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : IEquatable<Employee>
    {
        public Employee()
        {

        }

        public Employee(DataRow row)
        {
            Id = Int32.Parse(row["ID"].ToString());
            DepartmentID = row["DepartmentID"].ToString();
            SurName = row["SurName"].ToString();
            FirstName = row["FirstName"].ToString();
            Patronymic = row["Patronymic"].ToString();
            DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
            DocSeries = row["DocSeries"].ToString();
            DocNumber = row["DocNumber"].ToString();
            Position = row["Position"].ToString();
        }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                int year = dateNow.Year - DateOfBirth.Year;
                if (dateNow.Month < DateOfBirth.Month ||
                    (DateOfBirth.Month == dateNow.Month && dateNow.Day < DateOfBirth.Day))
                    year--;
                return year;

            }
        }

        /// <summary>
        /// Серия документа
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// должность
        /// </summary>
        public string Position { get; set; }

        public bool Equals(Employee other)
        {
            return Id.Equals(other.Id) && DepartmentID.Equals(other.DepartmentID) &&
                   SurName.Equals(other.SurName) && FirstName.Equals(other.FirstName) && Patronymic.Equals(other.Patronymic) &&
                   DateOfBirth.Equals(other.DateOfBirth) &&
                   DocSeries.Equals(other.DocSeries) && DocNumber.Equals(other.DocNumber) &&
                   Position.Equals(other.Position);
        }
    }
}
