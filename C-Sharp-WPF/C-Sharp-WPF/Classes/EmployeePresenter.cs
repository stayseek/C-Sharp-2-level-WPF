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
        private Employee currentEmployee;
        private IEmployeeView view;

        public EmployeePresenter(IEmployeeView View, Employee CurrentEmployee)
        {
            this.view = View;
            currentEmployee = CurrentEmployee;
        }

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
                view.ButtonContent = "Сохранить.";
            }
            else
            {
                view.ButtonContent = "Создать.";
            }
        }

        public void AddEmployee()
        {
            Model.EmployeeAdd(
                Model.EmployeesList.Count,
                view.EmployeeFirstName,
                view.EmployeeLastName,
                view.EmployeeAge,
                view.EmployeeSallary,
                view.EmployeeDepartmentId);
        }
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
