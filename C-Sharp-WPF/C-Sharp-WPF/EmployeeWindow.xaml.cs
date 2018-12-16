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

namespace C_Sharp_WPF
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        /// <summary>
        /// Основное окно.
        /// </summary>
        MainWindow parentWindow;
        /// <summary>
        /// Идентификатор элемента, с которым производится работа.
        /// </summary>
        int Id;
        /// <summary>
        /// Конструктор.
        /// </summary>
        public EmployeeWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Загрузка данных в форму.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="sallary">Зарплата.</param>
        /// <param name="departmentId">Уникальный номер подразделения.</param>
        /// <param name="departments">Список подразделений.</param>
        public void LoadParams(int id, string firstName, string lastName, int age, int sallary, int departmentId, List<Department> departments)
        {
            parentWindow = (MainWindow)this.Owner;
            tbEmployeeId.Text = id.ToString();
            Id = id;
            tbEmployeeFirstName.Text = firstName;
            tbEmployeeLastName.Text = lastName;
            tbEmployeeAge.Text = age.ToString();
            tbEmployeeSallary.Text = sallary.ToString();
            cbEmployeeDepartment.ItemsSource = departments;
            if (id == parentWindow.NextEmployeeId)
            {
                btnEmployeeConfirm.Content = "Создать";
                cbEmployeeDepartment.SelectedIndex = 0;
            }
            else
            {
                btnEmployeeConfirm.Content = "Обновить";
                cbEmployeeDepartment.SelectedIndex = departmentId;
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEmployeeConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (Id == parentWindow.NextEmployeeId)
            {
                parentWindow?.EmployeeAdd(parentWindow.NextEmployeeId, 
                    tbEmployeeFirstName.Text, 
                    tbEmployeeLastName.Text, 
                    int.Parse(tbEmployeeAge.Text), 
                    int.Parse(tbEmployeeSallary.Text), 
                    cbEmployeeDepartment.SelectedIndex); 
            }
            else
            {
                parentWindow?.EmployeeUpdate(Id, tbEmployeeFirstName.Text,
                    tbEmployeeLastName.Text,
                    int.Parse(tbEmployeeAge.Text),
                    int.Parse(tbEmployeeSallary.Text),
                    cbEmployeeDepartment.SelectedIndex);
            }
            this.Close();
        }
    }
}
