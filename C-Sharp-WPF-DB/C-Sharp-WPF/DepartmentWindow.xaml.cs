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
using System.Data;

namespace C_Sharp_WPF
{
    /// <summary>
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window, IDepartmentView
    {
        DepartmentPresenter p;
        /// <summary>
        /// Конструктор.
        /// </summary>
        public DepartmentWindow(DataRow CurrentDepartment)
        {
            InitializeComponent();
            p = new DepartmentPresenter(this,CurrentDepartment);
            btnConfirm.Click += delegate 
            {
                p.SaveData();
                DialogResult = true;
            };
            btnConfirm.Click += delegate { Close(); };
            this.Loaded += delegate { p.LoadData(); };
        }
        public string DepartmentName { get => tbDepartmentName.Text; set => tbDepartmentName.Text = value; }
    }
}
