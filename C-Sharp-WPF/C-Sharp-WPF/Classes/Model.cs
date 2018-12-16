﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace C_Sharp_WPF
{
    static class Model
    {
        /// <summary>
        /// Список сотрудников.
        /// </summary>
        static public ObservableCollection<Employee> EmployeesList = new ObservableCollection<Employee>();
        /// <summary>
        /// Список подразделений.
        /// </summary>
        static public ObservableCollection<Department> DepartmentsList = new ObservableCollection<Department>();
        /// <summary>
        /// Номер элемента, который будет присвоен при добавлении в список подразделений.
        /// </summary>
        static public int NextDepartmentId { get { return DepartmentsList.Count; } }
        /// <summary>
        /// Номер элемента, который будет присвоен при добавлении в список сотрудников.
        /// </summary>
        static public int NextEmployeeId { get { return EmployeesList.Count; } }
        /// <summary>
        /// Путь до файла со списком сотрудников.
        /// </summary>
        const string EMPLOYEESFILENAME = @"..\..\data\employeeslist.csv";
        /// <summary>
        /// Путь до файла со списком подразделений.
        /// </summary>
        const string DEPARTMENTSFILENAME = @"..\..\data\departmentslist.csv";
        /// <summary>
        /// Загрузка данных из CSV файлов в списки сотрудников и подразделений.
        /// </summary>
        static public void LoadCSVData()
        {
            using (var r = new StreamReader(EMPLOYEESFILENAME))
            {
                while (!r.EndOfStream)
                {
                    string[] s = r.ReadLine().Split(';');
                    EmployeesList.Add(new Employee(int.Parse(s[0]), s[1], s[2], int.Parse(s[3]), int.Parse(s[4]), int.Parse(s[5])));
                }
            }
            using (var r = new StreamReader(DEPARTMENTSFILENAME))
            {
                while (!r.EndOfStream)
                {
                    string[] s = r.ReadLine().Split(';');
                    DepartmentsList.Add(new Department(int.Parse(s[0]), s[1]));
                }
            }
        }
        /// <summary>
        /// Добавление сотрудника в список.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="sallary">Зарплата.</param>
        /// <param name="departmentId">Уникальный идентификатор подразделения.</param>
        static public void EmployeeAdd(int id, string firstName, string lastName, int age, int sallary, int departmentId)
        {
            EmployeesList.Add(new Employee(id, firstName, lastName, age, sallary, departmentId));
        }
        /// <summary>
        /// Добавление подразделения в список.
        /// </summary>
        /// <param name="id">Уникальный идентификатор подразделения.</param>
        /// <param name="name">Название подразделения.</param>
        static public void DepartmentAdd(int id, string name)
        {
            DepartmentsList.Add(new Department(id, name));
        }
        /// <summary>
        /// Обновление сотрудника в списке
        /// </summary>
        /// <param name="id">Номер элемента в списке.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="sallary">Зарплата.</param>
        /// <param name="departmentId">Уникальный идентификатор подразделения.</param>
        static public void EmployeeUpdate(int id, string firstName, string lastName, int age, int sallary, int departmentId)
        {
            EmployeesList[id].FirstName = firstName;
            EmployeesList[id].LastName = lastName;
            EmployeesList[id].Age = age;
            EmployeesList[id].Sallary = sallary;
            EmployeesList[id].DepartmentId = departmentId;
        }
        /// <summary>
        /// Обновление подразделения в списке.
        /// </summary>
        /// <param name="id">Уникальный идентификатор подразделения.</param>
        /// <param name="name">Название подразделения.</param>
        static public void DepartmentUpdate(int id, string name)
        {
            DepartmentsList[id].Name = name;
        }
    }
}
