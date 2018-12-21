using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace C_Sharp_WPF
{
    static class Model
    {
        /// <summary>
        /// Соединение.
        /// </summary>
        static SqlConnection connection;
        /// <summary>
        /// Адаптер таблицы сотрудников.
        /// </summary>
        static SqlDataAdapter employeesAdapter;
        /// <summary>
        /// Таблица сотрудников.
        /// </summary>
        public static DataTable employeesDt;
        /// <summary>
        /// Адаптер таблица подразделений.
        /// </summary>
        static SqlDataAdapter departmentsAdapter;
        /// <summary>
        /// Таблица подразделений.
        /// </summary>
        public static DataTable departmentsDt;
        /// <summary>
        /// Настройка подключения к БД.
        /// </summary>
        static public void InitializeDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            employeesAdapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(@"SELECT Id,FirstName,LastName,Age,Sallary,Department 
                                                  FROM Employees", connection);
            employeesAdapter.SelectCommand = command;

            command = new SqlCommand(@"INSERT INTO Employees (FirstName,LastName,Age,Sallary,Department)
                                       VALUES (@FirstName,@LastName,@Age,@Sallary,@Department);
                                       SET @Id = @@IDENTITY;",connection);
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, -1, "FirstName");
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, -1, "LastName");
            command.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            command.Parameters.Add("@Sallary", SqlDbType.Int, 0, "Sallary");
            command.Parameters.Add("@Department", SqlDbType.NVarChar, -1, "Department");
            SqlParameter param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            employeesAdapter.InsertCommand = command;

            command = new SqlCommand(@"UPDATE Employees 
                                       SET FirstName = @FirstName, 
                                           LastName = @LastName,
                                           Age = @Age,
                                           Sallary = @Sallary,
                                           Department = @Department
                                       WHERE Id = @Id", connection);
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, -1, "FirstName");
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, -1, "LastName");
            command.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            command.Parameters.Add("@Sallary", SqlDbType.Int, 0, "Sallary");
            command.Parameters.Add("@Department", SqlDbType.NVarChar, -1, "Department");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            employeesAdapter.UpdateCommand = command;

            command = new SqlCommand(@"DELETE FROM Employees WHERE Id = @Id", connection);
            command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            employeesAdapter.DeleteCommand = command;
        
            employeesDt = new DataTable();
            employeesAdapter.Fill(employeesDt);

            departmentsAdapter = new SqlDataAdapter();

            command = new SqlCommand(@"SELECT Id, DepartmentName 
                                                  FROM Departments", connection);
            departmentsAdapter.SelectCommand = command;

            command = new SqlCommand(@"INSERT INTO Departments (DepartmentName)
                                       VALUES (@DepartmentName);
                                       SET @Id = @@IDENTITY;", connection);
            command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, -1, "DepartmentName");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            departmentsAdapter.InsertCommand = command;

            command = new SqlCommand(@"UPDATE Departments SET DepartmentName = @DepartmentName WHERE Id = @Id;", connection);
            command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, -1, "DepartmentName");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            departmentsAdapter.UpdateCommand = command;

            command = new SqlCommand(@"DELETE FROM Departments WHERE Id = @Id", connection);
            command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            departmentsAdapter.DeleteCommand = command;

            departmentsDt = new DataTable();
            departmentsAdapter.Fill(departmentsDt);
        }
        /// <summary>
        /// Заполнение таблиц данными, если они пустые.
        /// </summary>
        static public void FillDB()
        {
            int i,j;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Departments", connection);
                i = (int)command.ExecuteScalar();
                command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                j = (int)command.ExecuteScalar();
                if (i == 0)
                {
                    for (i = 0; i < 10; i++)
                    {
                        command = new SqlCommand($@"INSERT INTO Employees (FirstName,LastName,Age,Sallary,Department)
                                       VALUES (N'Вася{i}',N'Пупкин{i}','{i+18}','{i*10000}',N'Подразделение{i}');", connection);
                        command.ExecuteNonQuery();
                    }
                }
                if (j == 0)
                {
                    for (i = 0; i < 10; i++)
                    {
                        command = new SqlCommand($@"INSERT INTO Departments (DepartmentName)
                                       VALUES (N'Подразделение{i}');", connection);
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
   
        }
        /// <summary>
        /// Добавление сотрудника в таблицу.
        /// </summary>
        /// <param name="employee">Сотрудник.</param>
        static public void EmployeeAdd(DataRow employee)
        {
            employeesDt.Rows.Add(employee);
            employeesAdapter.Update(employeesDt);
        }
        /// <summary>
        /// Добавление подразделения в таблицу.
        /// </summary>
        /// <param name="department">Подразделение.</param>
        static public void DepartmentAdd(DataRow department)
        {
            departmentsDt.Rows.Add(department);
            departmentsAdapter.Update(departmentsDt);
        }
        /// <summary>
        /// Обновление таблицы сотрудников.
        /// </summary>
        static public void EmployeeUpdate()
        {
            employeesAdapter.Update(employeesDt);
        }
        /// <summary>
        /// Обновление таблицы подразделений.
        /// </summary>
        static public void DepartmentUpdate()
        {
            departmentsAdapter.Update(departmentsDt);
        }
        /// <summary>
        /// Удаление сотрудника из таблицы.
        /// </summary>
        /// <param name="employeeRow">Удаляемый сотрудник.</param>
        static public void EmployeeDelete(DataRowView employeeRow)
        {
            employeeRow.Row.Delete();
            employeesAdapter.Update(employeesDt);
        }
        /// <summary>
        /// Удаление подразделения из таблицы.
        /// </summary>
        /// <param name="departmentRow">Удаляемое подразделение.</param>
        static public void DepartmentDelete(DataRowView departmentRow)
        {
            departmentRow.Row.Delete();
            departmentsAdapter.Update(departmentsDt);
        }
    }
}
