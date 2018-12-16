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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace C_Sharp_WPF
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window, IEmployeeView
    {
        EmployeePresenter p;
        /// <summary>
        /// Конструктор.
        /// </summary>
        public EmployeeWindow(Employee CurrentEmployee)
        {
            InitializeComponent();
            p = new EmployeePresenter(this, CurrentEmployee);
            if (CurrentEmployee == null)
            {
                btnEmployeeConfirm.Click += delegate { p.AddEmployee(); };
            }
            else
            {
                btnEmployeeConfirm.Click += delegate { p.UpdateEmployee(); };
            }
            btnEmployeeConfirm.Click += delegate { Close(); };
            this.Loaded += delegate { p.LoadData(); };
        }

        public string EmployeeFirstName { get => tbEmployeeFirstName.Text; set => tbEmployeeFirstName.Text = value; }
        public string EmployeeLastName { get => tbEmployeeLastName.Text; set => tbEmployeeLastName.Text = value; }
        public int EmployeeAge { get => int.Parse(tbEmployeeAge.Text); set => tbEmployeeAge.Text = value.ToString(); }
        public int EmployeeSallary { get => int.Parse(tbEmployeeSallary.Text); set => tbEmployeeSallary.Text = value.ToString(); }
        public int EmployeeDepartmentId { get => cbEmployeeDepartment.SelectedIndex; set => cbEmployeeDepartment.SelectedIndex = value; }
        public ObservableCollection<Department> DepartmentsList { set => cbEmployeeDepartment.ItemsSource = value; }
        public string ButtonContent { set => btnEmployeeConfirm.Content = value; }
    }
}
