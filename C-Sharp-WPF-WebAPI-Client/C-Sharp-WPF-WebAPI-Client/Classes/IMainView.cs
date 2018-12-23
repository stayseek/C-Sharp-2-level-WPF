using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

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
        ListView DepartmentsCollection { get; }
        /// <summary>
        /// Коллекция сотрудников.
        /// </summary>
        ListView EmployeesCollection { get; }
    }
}
