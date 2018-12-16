using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_WPF
{
    public class Department
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { private set; get; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="name">Название.</param>
        public Department (int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
