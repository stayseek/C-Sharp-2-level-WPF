using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace C_Sharp_WPF_WebAPI_Client
{
    interface IMainView
    {
        /// <summary>
        /// Выбранный сотрудник.
        /// </summary>
        Employee CurrentEmployee { get; }
        /// <summary>
        /// Выбранное подразделение.
        /// </summary>
        Department CurrentDepartment { get; }
        /// <summary>
        /// Коллекция подразделений.
        /// </summary>
        IEnumerable<Department> DepartmentsCollection { set; }
        /// <summary>
        /// Коллекция сотрудников.
        /// </summary>
        IEnumerable<Employee> EmployeesCollection { set; }
    }
}
