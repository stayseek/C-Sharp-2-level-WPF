using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF_WebAPI_Client
{
    public class Employee
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { set; get; }
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
        public string Department { set; get; }
    }
}
