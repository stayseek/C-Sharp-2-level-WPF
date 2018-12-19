using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace C_Sharp_WPF
{
    public class Employee : INotifyPropertyChanged
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { private set; get; }
        string firstName;
        string lastName;
        int age;
        int sallary;
        int departmentId;
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FirstName)));
            }
        }
        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.LastName)));
            }
        }
        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age
        {
            get => this.age;
            set
            {
                this.age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Age)));
            }
        }   
        /// <summary>
        /// Зарплата.
        /// </summary>
        public int Sallary
        {
            get => this.sallary;
            set
            {
                this.sallary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Sallary)));
            }
        }
        /// <summary>
        /// Уникальный идентификатор подразделения.
        /// </summary>
        public int DepartmentId
        {
            get => this.departmentId;
            set
            {
                this.departmentId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepartmentId)));
            }
        }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="sallary">Зарплата.</param>
        /// <param name="departmentId">Уникальный идентификатор подразделения.</param>
        public Employee (int id, string firstName, string lastName, int age, int sallary, int departmentId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sallary = sallary;
            DepartmentId = departmentId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
