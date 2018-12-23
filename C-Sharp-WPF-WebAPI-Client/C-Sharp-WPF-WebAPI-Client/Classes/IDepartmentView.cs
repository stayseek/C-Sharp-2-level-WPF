using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF_WebAPI_Client
{
    interface IDepartmentView
    {
        /// <summary>
        /// Идентификатор подразделения.
        /// </summary>
        int DepartmentId { set; get; }
        /// <summary>
        /// Название подразделения.
        /// </summary>
        string DepartmentName { set; get; }
    }
}
