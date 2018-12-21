using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            Model.LoadData();
            view.EmployeesCollection = Model.EmployeesList;
            view.DepartmentsCollection = Model.DepartmentsList;
        }
        public void SaveData()
        {
            Model.SaveData();
        }
        /// <summary>
        /// Вызор окна создания/редактирования сотрудника.
        /// </summary>
        /// <param name="EmployeeId">Идентификатор выбранного сотрудника.</param>
        public void ViewEmployee(int EmployeeId)
        {
            EmployeeWindow employeeWindow;
            if (EmployeeId > -1)
            {
                employeeWindow = new EmployeeWindow(Model.EmployeesList[EmployeeId]);
            }
            else
            {
                employeeWindow = new EmployeeWindow(null);
            }
            employeeWindow.Owner = (Window)this.view;
            employeeWindow.ShowDialog();

        }
        /// <summary>
        /// Вызор окна создания/редактирования подразделения.
        /// </summary>
        /// <param name="DepartmentId">Идентификатор выбранного подразделения.</param>
        public void ViewDepartment(int DepartmentId)
        {
            DepartmentWindow departmentWindow;
            if (DepartmentId > -1)
            {
                departmentWindow = new DepartmentWindow(Model.DepartmentsList[DepartmentId]);
            }
            else
            {
                departmentWindow = new DepartmentWindow(null);
            }
            departmentWindow.Owner = (Window)this.view;
            departmentWindow.ShowDialog();
        }
    }
}
