using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace C_Sharp_WPF
{
    public interface IMainView
    {
        /// <summary>
        /// Выбранный сотрудник.
        /// </summary>
        DataRowView CurrentEmployee { get; }
        /// <summary>
        /// Выбранное подразделение.
        /// </summary>
        DataRowView CurrentDepartment { get; }
        /// <summary>
        /// Коллекция подразделений.
        /// </summary>
        DataView DepartmentsCollection { set;}
        /// <summary>
        /// Коллекция сотрудников.
        /// </summary>
        DataView EmployeesCollection { set;}

    }
}
