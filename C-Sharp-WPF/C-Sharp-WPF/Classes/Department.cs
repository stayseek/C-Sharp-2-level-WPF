using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace C_Sharp_WPF
{
    public class Department : INotifyPropertyChanged
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { private set; get; }
        /// <summary>
        /// Название.
        /// </summary>
        string name;
        /// <summary>
        /// Название.
        /// </summary>
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }
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

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
