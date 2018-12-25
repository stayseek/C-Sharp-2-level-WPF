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
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window, IDepartmentView
    {
        DepartmentPresenter p;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="department">Отображаемое подразделение.</param>
        public DepartmentWindow(Department department, bool editable)
        {
            this.Resources.Add("editable", editable);
            InitializeComponent();
            p = new DepartmentPresenter(this,department);
            

            this.Loaded += delegate { p.LoadData(); };
            this.Closing += delegate { p.SaveData(); };
            btnConfirm.Click += delegate { DialogResult = true; Close(); };
        }

        public int DepartmentId { get => int.Parse(tbDepartmentId.Text); set => tbDepartmentId.Text = value.ToString(); }
        public string DepartmentName { get => tbDepartmentName.Text; set => tbDepartmentName.Text = value; }
    }
}
