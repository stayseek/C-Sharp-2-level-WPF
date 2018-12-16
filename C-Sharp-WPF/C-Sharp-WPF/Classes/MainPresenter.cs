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
            UpdateData();

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
            UpdateData();
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
            UpdateData();
        }

        public void UpdateData()
        {
            view.EmployeesCollection = null;
            view.EmployeesCollection = Model.EmployeesList;
            view.DepartmentsCollection = null;
            view.DepartmentsCollection = Model.DepartmentsList;
        }
    }
}
