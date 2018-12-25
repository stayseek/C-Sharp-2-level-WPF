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
        public void ShowRequestedEmployee()
        {
            if (view.CurrentEmployee != null)
            {
                EmployeeWindow employeeWindow;
                model.GetEmployeeWithId(view.CurrentEmployee.Id);
                Employee requestedEmployee = model.RequestedEmployee;
                if (requestedEmployee != null)
                {
                    employeeWindow = new EmployeeWindow(requestedEmployee,model.DepartmentsList as List<Department>,false);
                    employeeWindow.Owner = (Window)this.view;
                    employeeWindow.ShowDialog();
                }
            }
        }
        /// <summary>
        /// Запрос к серверу на получение данных определённого подразделения и показ его данных в отдельном окне.
        /// </summary>
        public void ShowRequestedDepartment()
        {
            if (view.CurrentDepartment != null)
            {
                DepartmentWindow departmentWindow;
                model.GetDepartmentWithId(view.CurrentDepartment.Id);
                Department requestedDepartment = model.RequestedDepartment;
                if (requestedDepartment != null)
                {
                    departmentWindow = new DepartmentWindow(requestedDepartment,false);
                    departmentWindow.Owner = (Window)this.view;
                    departmentWindow.ShowDialog();
                }
            }
        }
        /// <summary>
        /// Добавление подразделения в базу.
        /// </summary>
        public void AddDepartment()
        {
            DepartmentWindow departmentWindow;
            Department department = new Department();
            department.Id = 0;
            department.DepartmentName = default(string);
            departmentWindow = new DepartmentWindow(department, true);
            departmentWindow.Owner = (Window)this.view;
            departmentWindow.ShowDialog();
            if (departmentWindow.DialogResult.HasValue && departmentWindow.DialogResult.Value)
            {
                model.AddDepartment(department);
            }
        }
        /// <summary>
        /// Добавление сотрудника в базу.
        /// </summary>
        public void AddEmployee()
        {
            EmployeeWindow employeeWindow;
            Employee employee = new Employee();
            employee.Id = 0;
            employee.FirstName = default(string);
            employee.LastName = default(string);
            employee.Age = 0;
            employee.Sallary = 0;
            employee.Department = default(string);
            employeeWindow = new EmployeeWindow(employee, model.DepartmentsList as List<Department>, true);
            employeeWindow.Owner = (Window)this.view;
            employeeWindow.ShowDialog();
            if (employeeWindow.DialogResult.HasValue && employeeWindow.DialogResult.Value)
            {
                model.AddEmployee(employee);
            }
        }
    }
}
