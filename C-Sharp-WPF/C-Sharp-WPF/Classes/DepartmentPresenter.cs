using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace C_Sharp_WPF
{
    class DepartmentPresenter
    {
        /// <summary>
        /// Подразделение, с которым производятся действия.
        /// </summary>
        private DataRow currentDepartment;
        /// <summary>
        /// Форма для вывода.
        /// </summary>
        private IDepartmentView view;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="View">Форма для вывода.</param>
        /// <param name="CurrentDepartment">Подразделение.</param>
        public DepartmentPresenter(IDepartmentView View, DataRow CurrentDepartment)
        {
            this.view = View;
            currentDepartment = CurrentDepartment;
        }
        /// <summary>
        /// Загрузка данных в форму.
        /// </summary>
        public void LoadData()
        {
            view.DepartmentName = currentDepartment["DepartmentName"].ToString();
        }
        /// <summary>
        /// Выгрузка данных из формы.
        /// </summary>
        public void SaveData()
        {
            currentDepartment["DepartmentName"] = view.DepartmentName;
        }
    }
}
