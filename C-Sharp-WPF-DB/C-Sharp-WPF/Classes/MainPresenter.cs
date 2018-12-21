using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace C_Sharp_WPF
{
    class MainPresenter
    {
        /// <summary>
        /// Форма дя вывода.
        /// </summary>
        private IMainView view;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="View"></param>
        public MainPresenter(IMainView View)
        {
            this.view = View;
        }
        /// <summary>
        /// Загрузка данных и привязка данных в форму.
        /// </summary>
        public void LoadData()
        {
            Model.FillDB();
            Model.InitializeDB();
            view.EmployeesCollection = Model.employeesDt.DefaultView;
            view.DepartmentsCollection = Model.departmentsDt.DefaultView;
        }
        /// <summary>
        /// Вызор окна создания сотрудника.
        /// </summary>
        public void CreateEmployee()
        {
            EmployeeWindow employeeWindow;
            DataRow employee = Model.employeesDt.NewRow();
            employeeWindow = new EmployeeWindow(employee);
            employeeWindow.Owner = (Window)this.view;
            employeeWindow.ShowDialog();
            if (employeeWindow.DialogResult.HasValue && employeeWindow.DialogResult.Value)
            {
                Model.EmployeeAdd(employee);
            }
        }
        /// <summary>
        /// Вызов окна редактирования сотрудника.
        /// </summary>
        /// <param name="employee">Редактируемый сотрудник.</param>
        public void EditEmployee(DataRowView employee)
        {
            EmployeeWindow employeeWindow;
            employee.BeginEdit();
            employeeWindow = new EmployeeWindow(employee.Row);
            employeeWindow.Owner = (Window)this.view;
            employeeWindow.ShowDialog();
            if (employeeWindow.DialogResult.HasValue && employeeWindow.DialogResult.Value)
            {
                employee.EndEdit();
            }
            else
            {
                employee.CancelEdit();
            }
            Model.EmployeeUpdate();
        }
        /// <summary>
        /// Вызор окна создания подразделения.
        /// </summary>
        public void CreateDepartment()
        {
            DepartmentWindow departmentWindow;
            DataRow department = Model.departmentsDt​.NewRow​();
            departmentWindow = new DepartmentWindow(department);
            departmentWindow.Owner = (Window)this.view;
            departmentWindow.ShowDialog();
            if (departmentWindow.DialogResult.HasValue && departmentWindow.DialogResult.Value)
            {
                Model.DepartmentAdd(department); 
            }
        }
        /// <summary>
        /// Вызов окна редактирования подразделения.
        /// </summary>
        /// <param name="department">Редактируемое подразделение.</param>
        public void EditDepartment(DataRowView department)
        {
            DepartmentWindow departmentWindow;
            department.BeginEdit();
            departmentWindow = new DepartmentWindow(department.Row);
            departmentWindow.Owner = (Window)this.view;
            departmentWindow.ShowDialog();
            if (departmentWindow.DialogResult.HasValue && departmentWindow.DialogResult.Value)
            {
                department.EndEdit();
            }
            else
            {
                department.CancelEdit();
            }
            Model.DepartmentUpdate();
        }
        /// <summary>
        /// Удаление сотрудника.
        /// </summary>
        /// <param name="employee">Удаляемый сотрудник.</param>
        public void DeleteEmployee(DataRowView employee)
        {
            if (employee != null)
            {
                Model.EmployeeDelete(employee);
            }
        }
        /// <summary>
        /// Удаление подразделения.
        /// </summary>
        /// <param name="department">Удаляемое подразделение.</param>
        public void DeleteDepartment(DataRowView department)
        {
            if (department != null)
            {
                Model.DepartmentDelete(department);
            }
        }
    }
}
