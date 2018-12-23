using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace C_Sharp_WPF_WebAPI_Client
{
    class MainPresenter
    {
        /// <summary>
        /// Форма дя вывода.
        /// </summary>
        private IMainView view;
        private Model model;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="View"></param>
        public MainPresenter(IMainView View)
        {
            this.view = View;
            model = new Model();
        }
        /// <summary>
        /// Привязка данных в форму.
        /// </summary>
        public void LoadData()
        {
            view.EmployeesCollection.ItemsSource = model.EmployeesList;
            view.DepartmentsCollection.ItemsSource = model.DepartmentsList;
        }

        public void UpdateData()
        {
            view.EmployeesCollection.ItemsSource = null;
            view.DepartmentsCollection.ItemsSource = null;
            view.EmployeesCollection.ItemsSource = model.EmployeesList;
            view.DepartmentsCollection.ItemsSource = model.DepartmentsList;
        }
        /// <summary>
        /// Запрос к серверу на получение данных определённого сотрудника и показ его данных в отдельном окне.
        /// </summary>
        /// <param name="employee">Сотрудник.</param>
        public void ShowRequestedEmployee()
        {
            if (view.CurrentEmployee != null)
            {
                EmployeeWindow employeeWindow;
                model.GetEmployeeWithId(view.CurrentEmployee.Id);
                Employee requestedEmployee = model.RequestedEmployee;
                if (requestedEmployee != null)
                {
                    employeeWindow = new EmployeeWindow(requestedEmployee);
                    employeeWindow.Owner = (Window)this.view;
                    employeeWindow.ShowDialog();
                }
            }
        }
        /// <summary>
        /// Запрос к серверу на получение данных определённого подразделения и показ его данных в отдельном окне.
        /// </summary>
        /// <param name="employee">Подразделение.</param>
        public void ShowRequestedDepartment()
        {
            if (view.CurrentDepartment != null)
            {
                DepartmentWindow departmentWindow;
                model.GetDepartmentWithId(view.CurrentDepartment.Id);
                Department requestedDepartment = model.RequestedDepartment;
                if (requestedDepartment != null)
                {
                    departmentWindow = new DepartmentWindow(requestedDepartment);
                    departmentWindow.Owner = (Window)this.view;
                    departmentWindow.ShowDialog();
                }
            }
        }
    }
}
