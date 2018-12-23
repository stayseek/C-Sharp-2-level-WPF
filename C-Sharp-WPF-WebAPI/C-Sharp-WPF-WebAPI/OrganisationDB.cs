using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using C_Sharp_WPF_WebAPI.Models;

namespace C_Sharp_WPF_WebAPI
{
    public static class OrganisationDB
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
        static DataTable employeesDt;
        /// <summary>
        /// Адаптер таблица подразделений.
        /// </summary>
        static SqlDataAdapter departmentsAdapter;
        /// <summary>
        /// Таблица подразделений.
        /// </summary>
        static DataTable departmentsDt;
        /// <summary>
        /// Настройка подключения к БД.
        /// </summary>
        public static void InitializeDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            employeesAdapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(@"SELECT Id,FirstName,LastName,Age,Sallary,Department 
                                                  FROM Employees", connection);
            employeesAdapter.SelectCommand = command;

            command = new SqlCommand(@"INSERT INTO Employees (FirstName,LastName,Age,Sallary,Department)
                                       VALUES (@FirstName,@LastName,@Age,@Sallary,@Department);
                                       SET @Id = @@IDENTITY;", connection);
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
            employeesDt.PrimaryKey = new DataColumn[] { employeesDt.Columns["Id"] }; 

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
            departmentsDt.PrimaryKey = new DataColumn[] { departmentsDt.Columns["Id"] };
        }
        /// <summary>
        /// Заполнение таблиц данными, если они пустые.
        /// </summary>
        public static void FillDB()
        {
            int i, j;
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
                                       VALUES (N'Вася{i}',N'Пупкин{i}','{i + 18}','{i * 10000}',N'Подразделение{i}');", connection);
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
        /// Выдача списка сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public static List<Employee> GetEmployeesList()
        {
            List<Employee> employeesList = new List<Employee>();
            foreach (DataRow row in employeesDt.Rows)
            {
                Employee employee = new Employee();
                employee.Id = int.Parse(row["Id"].ToString());
                employee.FirstName = row["FirstName"].ToString();
                employee.LastName = row["LastName"].ToString();
                employee.Age = int.Parse(row["Age"].ToString());
                employee.Sallary = int.Parse(row["Sallary"].ToString());
                employee.Department = row["Department"].ToString();
                employeesList.Add(employee);
            }
            return employeesList;
        }
        /// <summary>
        /// Выдача списка подразделений.
        /// </summary>
        /// <returns>Список подразделений.</returns>
        public static List<Department> GetDepartmentsList()
        {
            List<Department> departmentsList = new List<Department>();
            foreach (DataRow row in departmentsDt.Rows)
            {
                Department department = new Department();
                department.Id = int.Parse(row["Id"].ToString());
                department.DepartmentName = row["DepartmentName"].ToString();
                departmentsList.Add(department);
            }
            return departmentsList;
        }
        /// <summary>
        /// Выдача сотрудника с определённым идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Сотрудник.</returns>
        public static Employee GetEmployeeWithId (int id)
        {
            DataRow dataRow = employeesDt.Rows.Find(id);
            if (dataRow != null)
            {
                Employee employee = new Employee();
                employee.Id = int.Parse(dataRow["Id"].ToString());
                employee.FirstName = dataRow["FirstName"].ToString();
                employee.LastName = dataRow["LastName"].ToString();
                employee.Age = int.Parse(dataRow["Age"].ToString());
                employee.Sallary = int.Parse(dataRow["Sallary"].ToString());
                employee.Department = dataRow["Department"].ToString();
                return employee;
            }
            else { return null; }
        }
        /// <summary>
        /// Выдача подразделения с определённым идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Подразделение.</returns>
        public static Department GetDepartmentWithId(int id)
        {
            DataRow dataRow = departmentsDt.Rows.Find(id);
            if (dataRow != null)
            {
                Department department = new Department();
                department.Id = int.Parse(dataRow["Id"].ToString());
                department.DepartmentName = dataRow["DepartmentName"].ToString();
                return department;
            }
            else { return null; }
        }
    }
}