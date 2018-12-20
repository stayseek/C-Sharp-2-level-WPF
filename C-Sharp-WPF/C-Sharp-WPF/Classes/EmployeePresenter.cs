using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace C_Sharp_WPF
{
    class EmployeePresenter
    {
        /// <summary>
        /// Сотрудник, над которым производятся действия.
        /// </summary>
        private DataRow currentEmployee;
        /// <summary>
        /// Форма для вывода.
        /// </summary>
        private IEmployeeView view;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="View">Форма для вывода.</param>
        /// <param name="CurrentEmployee">Сотрудник.</param>
        public EmployeePresenter(IEmployeeView View, DataRow CurrentEmployee)
        {
            this.view = View;
            currentEmployee = CurrentEmployee;
        }
        /// <summary>
        /// Загрузка данных в форму.
        /// </summary>
        public void LoadData()
        { 
            view.DepartmentsList = Model.departmentsDt;
            view.EmployeeFirstName = currentEmployee["FirstName"].ToString();
            view.EmployeeLastName = currentEmployee["LastName"].ToString();
            view.EmployeeAge = currentEmployee["Age"].ToString();
            view.EmployeeSallary = currentEmployee["Sallary"].ToString();
            view.EmployeeDepartment = currentEmployee["Department"].ToString();
        }
        /// <summary>
        /// Выгрузка данных из формы.
        /// </summary>
        public void SaveData()
        {
            currentEmployee["FirstName"] = view.EmployeeFirstName;
            currentEmployee["LastName"] = view.EmployeeLastName;
            currentEmployee["Age"] = view.EmployeeAge;
            currentEmployee["Sallary"] = view.EmployeeSallary;
            currentEmployee["Department"] = view.EmployeeDepartment;
        }
    }
}
