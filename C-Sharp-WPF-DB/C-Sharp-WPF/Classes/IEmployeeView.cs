using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace C_Sharp_WPF
{
    public interface IEmployeeView
    {
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
        string EmployeeAge { set; get; }
        /// <summary>
        /// Зарплата.
        /// </summary>
        string EmployeeSallary { set; get; }
        /// <summary>
        /// Подразделение.
        /// </summary>
        string EmployeeDepartment { set; get; }

        /// <summary>
        /// Список подразделений.
        /// </summary>
        DataTable DepartmentsList { set; }
    }
}
