using System;
using System.Collections.Generic;
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
using System.IO;
using System.Collections.ObjectModel;

namespace C_Sharp_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        MainPresenter p;
        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            p = new MainPresenter(this);

            btnEmployeeEdit.Click += delegate { p.ViewEmployee(CurrentEmployee); };
            btnEmployeeCreate.Click += delegate { p.ViewEmployee(-1); };

            btnDepatrmentEdit.Click += delegate { p.ViewDepartment(CurrentDepartment); };
            btnDepartmentCreate.Click += delegate { p.ViewDepartment(-1); };

            this.Loaded += delegate { p.LoadData();};
            this.Closing += delegate { p.SaveData(); };
        }
        public ObservableCollection<Department> DepartmentsCollection { set => lvDepartmentList.ItemsSource = value;}
        public ObservableCollection<Employee> EmployeesCollection { set => lvEmployeeList.ItemsSource = value;}
        public int CurrentEmployee => lvEmployeeList.SelectedIndex;
        public int CurrentDepartment => lvDepartmentList.SelectedIndex;
    }
}
