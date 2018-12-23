using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C_Sharp_WPF_WebAPI.Models
{
    public class Department
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// Название.
        /// </summary>
        public string DepartmentName { set; get; }
    }
}