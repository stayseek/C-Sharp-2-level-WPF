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


            this.Loaded += delegate { p.LoadData(); };
        }

        public Employee CurrentEmployee => dgEmployeesList.SelectedItem as Employee;
        public Department CurrentDepartment => lvDepartmentList.SelectedItem as Department;

        public IEnumerable<Department> DepartmentsCollection { set => lvDepartmentList.ItemsSource = value; }
        public IEnumerable<Employee> EmployeesCollection { set => dgEmployeesList.ItemsSource = value; }
    }
}
