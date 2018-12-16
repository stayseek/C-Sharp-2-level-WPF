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
        private IMainView view;

        public MainPresenter(IMainView View)
        {
            this.view = View;
        }

        public void LoadData()
        {
            Model.LoadCSVData();

            if (Model.DepartmentsList.Count > 0)
            {
                view.DepartmentsCollection = Model.DepartmentsList;

            }
            if (Model.EmployeesList.Count > 0)
            {
                view.EmployeesCollection = Model.EmployeesList;
            }
        }

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
            view.EmployeesCollection = null;
            view.EmployeesCollection = Model.EmployeesList;
        }

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
            view.DepartmentsCollection = null;
            view.DepartmentsCollection = Model.DepartmentsList;
        }
    }
}
