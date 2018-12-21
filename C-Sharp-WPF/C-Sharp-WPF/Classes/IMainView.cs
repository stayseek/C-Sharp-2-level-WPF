using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace C_Sharp_WPF
{
    public interface IMainView
    {
        /// <summary>
        /// Выбранный сотрудник.
        /// </summary>
        int CurrentEmployee { get; }
        /// <summary>
        /// Выбранное подразделение.
        /// </summary>
        int CurrentDepartment { get; }
        /// <summary>
        /// Коллекция подразделений.
        /// </summary>
        ObservableCollection<Department> DepartmentsCollection { set;}
        /// <summary>
        /// Коллекция сотрудников.
        /// </summary>
        ObservableCollection<Employee> EmployeesCollection { set;}

    }
}
