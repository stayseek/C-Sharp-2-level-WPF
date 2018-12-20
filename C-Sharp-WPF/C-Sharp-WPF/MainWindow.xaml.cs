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
using System.Data;

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

            btnEmployeeEdit.Click += delegate { p.EditEmployee(CurrentEmployee); };
            btnEmployeeCreate.Click += delegate { p.CreateEmployee(); };
            btnEmployeeDelete.Click += delegate { p.DeleteEmployee(CurrentEmployee); };

            btnDepatrmentEdit.Click += delegate { p.EditDepartment(CurrentDepartment); };
            btnDepartmentCreate.Click += delegate { p.CreateDepartment(); };
            btnDepatrmentDelete.Click += delegate { p.DeleteDepartment(CurrentDepartment); };

            this.Loaded += delegate { p.LoadData();};
        }

        public DataRowView CurrentEmployee => dgEmployeesList.SelectedItem as DataRowView;
        public DataRowView CurrentDepartment => dgDepartmentsList.SelectedItem as DataRowView;
        public DataView DepartmentsCollection { set => dgDepartmentsList.DataContext = value; }
        public DataView EmployeesCollection { set => dgEmployeesList.DataContext = value; }
    }
}
