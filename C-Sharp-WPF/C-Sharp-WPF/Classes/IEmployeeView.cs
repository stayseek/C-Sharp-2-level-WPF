using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        int EmployeeAge { set; get; }
        /// <summary>
        /// Зарплата.
        /// </summary>
        int EmployeeSallary { set; get; }
        /// <summary>
        /// Уникальный идентификатор подразделения.
        /// </summary>
        int EmployeeDepartmentId { set; get; }
        /// <summary>
        /// Текст кнопки.
        /// </summary>
        string ButtonContent { set; }
        /// <summary>
        /// Список подразделений.
        /// </summary>
        ObservableCollection<Department> DepartmentsList {set;}
    }
}
