using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace C_Sharp_WPF
{
    class EmployeePresenter
    {
        /// <summary>
        /// Сотрудник, над которым производятся действия.
        /// </summary>
        private Employee currentEmployee;
        /// <summary>
        /// Форма для вывода.
        /// </summary>
        private IEmployeeView view;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="View">Форма для вывода.</param>
        /// <param name="CurrentEmployee">Сотрудник.</param>
        public EmployeePresenter(IEmployeeView View, Employee CurrentEmployee)
        {
            this.view = View;
            currentEmployee = CurrentEmployee;
        }
        /// <summary>
        /// Привязка данных в форму.
        /// </summary>
        public void LoadData()
        {
            view.DepartmentsList = Model.DepartmentsList;
            if (currentEmployee != null)
            {
                view.EmployeeFirstName = currentEmployee.FirstName;
                view.EmployeeLastName = currentEmployee.LastName;
                view.EmployeeAge = currentEmployee.Age;
                view.EmployeeSallary = currentEmployee.Sallary;
                view.EmployeeDepartmentId = currentEmployee.DepartmentId;
                view.ButtonContent = "Сохранить";
            }
            else
            {
                view.ButtonContent = "Создать";
            }
        }
        /// <summary>
        /// Добавление сотрудника в список.
        /// </summary>
        public void AddEmployee()
        {
            Model.EmployeeAdd(
                Model.NextEmployeeId,
                view.EmployeeFirstName,
                view.EmployeeLastName,
                view.EmployeeAge,
                view.EmployeeSallary,
                view.EmployeeDepartmentId);
        }
        /// <summary>
        /// Редакторование сотрудника в списке.
        /// </summary>
        public void UpdateEmployee()
        {
            Model.EmployeeUpdate(currentEmployee.Id, 
                view.EmployeeFirstName,
                view.EmployeeLastName,
                view.EmployeeAge,
                view.EmployeeSallary,
                view.EmployeeDepartmentId);
        }
    }
}
