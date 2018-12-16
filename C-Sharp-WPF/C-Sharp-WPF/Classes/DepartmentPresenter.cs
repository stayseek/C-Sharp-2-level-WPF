using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF
{
    class DepartmentPresenter
    {
        private Department currentDepartment;
        private IDepartmentView view;

        public DepartmentPresenter(IDepartmentView View, Department CurrentDepartment)
        {
            this.view = View;
            currentDepartment = CurrentDepartment;
        }

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

        public void AddDepartment()
        {
            Model.DepartmentAdd(Model.DepartmentsList.Count,view.DepartmentName);
        }
        public void UpdateDepartment()
        {
            Model.DepartmentUpdate(currentDepartment.Id,view.DepartmentName);
        }
    }
}
