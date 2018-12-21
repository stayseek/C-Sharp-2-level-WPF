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
using System.Data;

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
        public EmployeeWindow(DataRow CurrentEmployee)
        {
            InitializeComponent();
            p = new EmployeePresenter(this, CurrentEmployee);
            btnEmployeeConfirm.Click += delegate 
            {
                p.SaveData();
                DialogResult = true;
            };
            btnEmployeeConfirm.Click += delegate { Close(); };
            this.Loaded += delegate { p.LoadData(); };
        }

        public string EmployeeFirstName { get => tbEmployeeFirstName.Text; set => tbEmployeeFirstName.Text = value; }
        public string EmployeeLastName { get => tbEmployeeLastName.Text; set => tbEmployeeLastName.Text = value; }
        public string EmployeeAge { get => tbEmployeeAge.Text; set => tbEmployeeAge.Text = value; }
        public string EmployeeSallary { get => tbEmployeeSallary.Text; set => tbEmployeeSallary.Text = value; }
        public DataTable DepartmentsList { set => cbEmployeeDepartment.ItemsSource = value.DefaultView; }
        public string EmployeeDepartment { get => (cbEmployeeDepartment.SelectedItem as DataRowView)["DepartmentName"].ToString(); set => cbEmployeeDepartment.Text = value; }
    }
}
