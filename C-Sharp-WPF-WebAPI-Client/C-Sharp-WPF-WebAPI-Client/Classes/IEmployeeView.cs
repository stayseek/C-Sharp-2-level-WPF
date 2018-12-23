using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF_WebAPI_Client
{
    interface IEmployeeView
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        int EmployeeId { set; get; }
        /// <summary>
        /// Имя.
        /// </summary>
        string EmployeeFirstName { set; get; }
        /// <summary>
        /// Фамилия.
        /// </summary>
        string EmployeeLastName { set; get; }
        /// <summary>
        /// Возраст.
        /// </summary>
        int EmployeeAge { set; get; }
        /// <summary>
        /// Зарплата.
        /// </summary>
        int EmployeeSallary { set; get; }
        /// <summary>
        /// Уникальный идентификатор подразделения.
        /// </summary>
        string EmployeeDepartment { set; get; }
    }
}
