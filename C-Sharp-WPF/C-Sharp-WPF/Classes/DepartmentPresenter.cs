using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF
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
            if (currentDepartment != null)
            {
                view.DepartmentName = currentDepartment.Name;
                view.ButtonContent = "Сохранить";
            }
            else
            {
                view.ButtonContent = "Создать";
            }
        }
        /// <summary>
        /// Добавление подразделения в список.
        /// </summary>
        public void AddDepartment()
        {
            Model.DepartmentAdd(Model.NextDepartmentId,view.DepartmentName);
        }
        /// <summary>
        /// Редактирование подразделения в списке.
        /// </summary>
        public void UpdateDepartment()
        {
            Model.DepartmentUpdate(currentDepartment.Id,view.DepartmentName);
        }
    }
}
