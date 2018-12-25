using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace C_Sharp_WPF_WebAPI_Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        MainPresenter p;
        public MainWindow()
        {
            InitializeComponent();
            p = new MainPresenter(this);

            btnEmployeeViewRequest.Click += delegate { p.ShowRequestedEmployee(); };
            btnDepatrmentViewRequest.Click += delegate { p.ShowRequestedDepartment(); };
            btnEmployeeAdd.Click += delegate { p.AddEmployee(); };
            btnDepatrmentAdd.Click += delegate { p.AddDepartment(); };
            btnUpdate.Click += delegate { p.UpdateData(); };
            this.Loaded += delegate { p.LoadData(); };
        }

        public Employee CurrentEmployee => lvEmployeesList.SelectedItem as Employee;
        public Department CurrentDepartment => lvDepartmentList.SelectedItem as Department;

        public ListView DepartmentsCollection { get => lvDepartmentList; }
        public ListView EmployeesCollection { get => lvEmployeesList; }
    }
}
