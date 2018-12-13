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
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
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
        public DepartmentWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Загрузка данных в форму.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="name">Название подразделения.</param>
        public void LoadParams(int id, string name)
        {
            parentWindow = (MainWindow)this.Owner;
            tbDepartmentId.Text = id.ToString();
            Id = id;
            tbDepartmentName.Text = name;
            if (id == parentWindow?.NextDepartmentId)
            {
                btnConfirm.Content = "Создать";
            }
            else
            {
                btnConfirm.Content = "Обновить";
            }
        }
        /// <summary>
        /// Обработчик события нажатия на кнопку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (Id == parentWindow.NextDepartmentId)
            {
                parentWindow?.DepartmentAdd(parentWindow.NextDepartmentId, tbDepartmentName.Text);
            }
            else
            {
                parentWindow?.DepartmentUpdate(Id, tbDepartmentName.Text);
            }
            this.Close();
        }
    }
}
