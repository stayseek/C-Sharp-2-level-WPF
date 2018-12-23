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

namespace C_Sharp_WPF_WebAPI_Client
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
        /// <param name="employee">Отображаемый сотрудник.</param>
        public EmployeeWindow(Employee employee)
        {
            InitializeComponent();
            p = new EmployeePresenter(this, employee);

            this.Loaded += delegate { p.LoadData(); };
            btnConfirm.Click += delegate { Close(); };
        }

        public int EmployeeId { get => int.Parse(tbEmployeeId.Text); set => tbEmployeeId.Text = value.ToString(); }
        public string EmployeeFirstName { get => tbEmployeeFirstName.Text; set => tbEmployeeFirstName.Text = value; }
        public string EmployeeLastName { get => tbEmployeeLastName.Text; set => tbEmployeeLastName.Text = value; }
        public int EmployeeAge { get => int.Parse(tbEmployeeAge.Text); set => tbEmployeeAge.Text = value.ToString(); }
        public int EmployeeSallary { get => int.Parse(tbEmployeeSallary.Text); set => tbEmployeeSallary.Text = value.ToString(); }
        public string EmployeeDepartment { get => tbEmployeeDepartment.Text; set => tbEmployeeDepartment.Text = value; }
    }
}
