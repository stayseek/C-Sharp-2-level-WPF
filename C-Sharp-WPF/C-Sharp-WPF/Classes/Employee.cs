using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF
{
    public class Employee
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { private set; get; }
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { set; get; }
        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { set; get; }
        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { set; get; }
        /// <summary>
        /// Зарплата.
        /// </summary>
        public int Sallary { set; get; }
        /// <summary>
        /// Уникальный идентификатор подразделения.
        /// </summary>
        public int DepartmentId { set; get; }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="sallary">Зарплата.</param>
        /// <param name="departmentId">Уникальный идентификатор подразделения.</param>
        public Employee (int id, string firstName, string lastName, int age, int sallary, int departmentId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sallary = sallary;
            DepartmentId = departmentId;
        }

        public override string ToString()
        {
            return ($"{LastName} {FirstName}\t{Age}\t{Sallary}\t{Model.DepartmentsList[DepartmentId].Name}");
        }

    }
}
