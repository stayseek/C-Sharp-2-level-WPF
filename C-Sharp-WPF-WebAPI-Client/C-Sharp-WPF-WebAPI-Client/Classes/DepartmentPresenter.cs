using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF_WebAPI_Client
{
    class DepartmentPresenter
    {
        /// <summary>
        /// Подразделение, с которым производится действие.
        /// </summary>
        private Department currentDepartment;
        /// <summary>
        /// Форма для вывода.
        /// </summary>
        private IDepartmentView view;
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="View">Форма для вывода.</param>
        /// <param name="CurrentDepartment">Подразделение.</param>
        public DepartmentPresenter(IDepartmentView View, Department CurrentDepartment)
        {
            this.view = View;
            currentDepartment = CurrentDepartment;
        }
        /// <summary>
        /// Привязка данных в форме.
        /// </summary>
        public void LoadData()
        {
            view.DepartmentId = currentDepartment.Id;
            view.DepartmentName = currentDepartment.DepartmentName;
        }
        /// <summary>
        /// Сохранение данных из формы.
        /// </summary>
        public void SaveData()
        {
            currentDepartment.Id = view.DepartmentId;
            currentDepartment.DepartmentName = view.DepartmentName;
        }
    }
}
