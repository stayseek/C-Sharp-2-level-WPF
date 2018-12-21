using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF
{
    public interface IDepartmentView
    {
        /// <summary>
        /// Название подразделения.
        /// </summary>
        string DepartmentName { set; get; }
    }
}
