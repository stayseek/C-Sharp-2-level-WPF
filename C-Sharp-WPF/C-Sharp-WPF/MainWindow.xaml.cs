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

namespace C_Sharp_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Список сотрудников.
        /// </summary>
        private List<Employee> EmployeesList = new List<Employee>();
        /// <summary>
        /// Список подразделений.
        /// </summary>
        private List<Department> DepartmentsList = new List<Department>();
        /// <summary>
        /// Номер элемента, который будет присвоен при добавлении в список подразделений.
        /// </summary>
        public int NextDepartmentId { get { return DepartmentsList.Count; }  }
        /// <summary>
        /// Номер элемента, который будет присвоен при добавлении в список сотрудников.
        /// </summary>
        public int NextEmployeeId { get { return EmployeesList.Count; } }
        /// <summary>
        /// Путь до файла со списком сотрудников.
        /// </summary>
        const string EMPLOYEESFILENAME = @"..\..\data\employeeslist.csv";
        /// <summary>
        /// Путь до файла со списком подразделений.
        /// </summary>
        const string DEPARTMENTSFILENAME = @"..\..\data\departmentslist.csv";
        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            lbEmployeeList.ItemsSource = EmployeesList;
            lbDepartmentList.ItemsSource = DepartmentsList;
            LoadCSVData();
        }
        /// <summary>
        /// Загрузка данных из CSV файлов в списки сотрудников и подразделений.
        /// </summary>
        private void LoadCSVData()
        {
            using (var r = new StreamReader(EMPLOYEESFILENAME))
            {
                while (!r.EndOfStream)
                {
                    string[] s = r.ReadLine().Split(';');
                    EmployeesList.Add(new Employee(int.Parse(s[0]), s[1], s[2], int.Parse(s[3]), int.Parse(s[4]), int.Parse(s[5])));
                }
            }
            using (var r = new StreamReader(DEPARTMENTSFILENAME))
            {
                while (!r.EndOfStream)
                {
                    string[] s = r.ReadLine().Split(';');
                    DepartmentsList.Add(new Department(int.Parse(s[0]), s[1]));
                }
            }
        }
        /// <summary>
        /// Добавление сотрудника в список.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="sallary">Зарплата.</param>
        /// <param name="departmentId">Уникальный идентификатор подразделения.</param>
        public void EmployeeAdd (int id, string firstName, string lastName, int age, int sallary, int departmentId)
        {
            EmployeesList.Add(new Employee(id, firstName, lastName, age, sallary, departmentId));
            lbEmployeeList.ItemsSource = null;
            lbEmployeeList.ItemsSource = EmployeesList;
        }
        /// <summary>
        /// Добавление подразделения в список.
        /// </summary>
        /// <param name="id">Уникальный идентификатор подразделения.</param>
        /// <param name="name">Название подразделения.</param>
        public void DepartmentAdd(int id, string name)
        {
            DepartmentsList.Add(new Department(id, name));
            lbDepartmentList.ItemsSource = null;
            lbDepartmentList.ItemsSource = DepartmentsList;
        }
        /// <summary>
        /// Обновление сотрудника в списке
        /// </summary>
        /// <param name="id">Номер элемента в списке.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="sallary">Зарплата.</param>
        /// <param name="departmentId">Уникальный идентификатор подразделения.</param>
        public void EmployeeUpdate(int id, string firstName, string lastName, int age, int sallary, int departmentId)
        {
            EmployeesList[id].FirstName = firstName;
            EmployeesList[id].LastName = lastName;
            EmployeesList[id].Age = age;
            EmployeesList[id].Sallary = sallary;
            EmployeesList[id].DepartmentId = departmentId;
            lbEmployeeList.ItemsSource = null;
            lbEmployeeList.ItemsSource = EmployeesList;
        }
        /// <summary>
        /// Обновление подразделения в списке.
        /// </summary>
        /// <param name="id">Уникальный идентификатор подразделения.</param>
        /// <param name="name">Название подразделения.</param>
        public void DepartmentUpdate(int id, string name)
        {
            DepartmentsList[id].Name = name;
            lbDepartmentList.ItemsSource = null;
            lbDepartmentList.ItemsSource = DepartmentsList;
        }
        /// <summary>
        /// Обработчик нажатия на кнопку создания подразделения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepartmentCreate_Click(object sender, RoutedEventArgs e)
        {
            DepartmentWindow departmentWindow = new DepartmentWindow();
            departmentWindow.Owner = this;
            departmentWindow.LoadParams(NextDepartmentId, string.Empty);
            departmentWindow.ShowDialog();
        }
        /// <summary>
        /// Обработчик нажатия на кнопку редактирования подразделения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepatrmentEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lbDepartmentList.SelectedIndex != -1)
            {
                DepartmentWindow departmentWindow = new DepartmentWindow();
                departmentWindow.Owner = this;
                departmentWindow.LoadParams(DepartmentsList[lbDepartmentList.SelectedIndex].Id, DepartmentsList[lbDepartmentList.SelectedIndex].Name);
                departmentWindow.ShowDialog();
            }
        }
        /// <summary>
        /// Обработчик нажатия на кнопку создания сотрудника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmployeeCreate_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Owner = this;
            employeeWindow.LoadParams(NextDepartmentId, string.Empty, string.Empty,0,0,0,DepartmentsList);
            employeeWindow.ShowDialog();
        }
        /// <summary>
        /// Обработчик нажатия на кнопку редактирования сотрудника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmployeeEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbEmployeeList.SelectedIndex != -1)
            {
                EmployeeWindow employeeWindow = new EmployeeWindow();
                employeeWindow.Owner = this;
                employeeWindow.LoadParams(EmployeesList[lbEmployeeList.SelectedIndex].Id, 
                    EmployeesList[lbEmployeeList.SelectedIndex].FirstName,
                    EmployeesList[lbEmployeeList.SelectedIndex].LastName,
                    EmployeesList[lbEmployeeList.SelectedIndex].Age,
                    EmployeesList[lbEmployeeList.SelectedIndex].Sallary,
                    EmployeesList[lbEmployeeList.SelectedIndex].DepartmentId,
                    DepartmentsList);
                employeeWindow.ShowDialog();
            }
        }
    }
}
