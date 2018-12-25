using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF_WebAPI_Client
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
        /// Список подразделений.
        /// </summary>
        private List<Department> departmentsList;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="View">Форма для вывода.</param>
        /// <param name="CurrentEmployee">Сотрудник.</param>
        public EmployeePresenter(IEmployeeView View, Employee CurrentEmployee, List<Department> DepartmentsList )
        {
            this.view = View;
            currentEmployee = CurrentEmployee;
            departmentsList = DepartmentsList;
        }
        /// <summary>
        /// Привязка данных в форму.
        /// </summary>
        public void LoadData()
        {
            if (currentEmployee != null)
            {
                view.EmployeeId = currentEmployee.Id;
                view.EmployeeFirstName = currentEmployee.FirstName;
                view.EmployeeLastName = currentEmployee.LastName;
                view.EmployeeAge = currentEmployee.Age;
                view.EmployeeSallary = currentEmployee.Sallary;
                view.EmployeeDepartment = departmentsList.FirstOrDefault(d => d.DepartmentName==currentEmployee.Department);
                view.DepartmentsList = departmentsList;
            }
        }
        /// <summary>
        /// Сохранение данных из формы.
        /// </summary>
        public void SaveData()
        {
            currentEmployee.Id = view.EmployeeId;
            currentEmployee.FirstName = view.EmployeeFirstName;
            currentEmployee.LastName = view.EmployeeLastName;
            currentEmployee.Age = view.EmployeeAge;
            currentEmployee.Sallary = view.EmployeeSallary;
            currentEmployee.Department = view.EmployeeDepartment.DepartmentName;
        }
    }
}
