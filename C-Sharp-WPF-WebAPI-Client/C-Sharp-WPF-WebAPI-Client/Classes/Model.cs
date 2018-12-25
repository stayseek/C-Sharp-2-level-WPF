using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace C_Sharp_WPF_WebAPI_Client
{
    public class Model
    {
        /// <summary>
        /// Список сотрудников.
        /// </summary>
        public IEnumerable<Employee> EmployeesList = new List<Employee>();
        /// <summary>
        /// Список подразделений.
        /// </summary>
        public IEnumerable<Department> DepartmentsList = new List<Department>();
        /// <summary>
        /// Запрашиваемый сотрудник.
        /// </summary>
        public Employee RequestedEmployee;
        /// <summary>
        /// Запрашиваемое подразделение.
        /// </summary>
        public Department RequestedDepartment;
        /// <summary>
        /// Клиент для запроса к сервису.
        /// </summary>
        static HttpClient client = new HttpClient();
        /// <summary>
        /// Конструктор.
        /// </summary>
        public Model()
        {
            client.BaseAddress = new Uri("http://localhost:51343/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            LoadData();
        }
        /// <summary>
        /// Загрузка данных из сервиса.
        /// </summary>
        void LoadData()
        {
            LoadEmployees();
            LoadDepartments();
        }
        /// <summary>
        /// Загрузка списка сотрудников из сервиса.
        /// </summary>
        async void LoadEmployees()
        {
            EmployeesList = await GetElementsAsync<Employee>(client.BaseAddress + "getemployees");
        }
        /// <summary>
        /// Загрузка списка подразделений из сервиса.
        /// </summary>
        async void LoadDepartments()
        {
            DepartmentsList = await GetElementsAsync<Department>(client.BaseAddress + "getdepartments");
        }
        /// <summary>
        /// Получение данных для сотрудника с определённым идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        async public void GetEmployeeWithId(int id)
        {
            RequestedEmployee = await GetElementAsync<Employee>(client.BaseAddress+ "getemployees/" + id);
        }
        /// <summary>
        /// Получение данных для подразделения с определённым идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        async public void GetDepartmentWithId(int id)
        {
            RequestedDepartment = await GetElementAsync<Department>(client.BaseAddress + "getdepartments/" + id);
        }
        /// <summary>
        /// Добавление подразделения в базу.
        /// </summary>
        /// <param name="department">Подразделение.</param>
        public void AddDepartment(Department department)
        {
            AddElement<Department>(department, client.BaseAddress + "adddepartment");
        }
        /// <summary>
        /// Добавление сотрудника в базу.
        /// </summary>
        /// <param name="employee">Сотрудник.</param>
        public void AddEmployee(Employee employee)
        {
            AddElement<Employee>(employee, client.BaseAddress + "addemployee");
        }
        /// <summary>
        /// Асинхронное получение списка элементов от сервиса.
        /// </summary>
        /// <typeparam name="T">Тип элемента</typeparam>
        /// <param name="path">Ссылка.</param>
        /// <returns>Список.</returns>
        static async Task<IEnumerable<T>> GetElementsAsync<T>(string path)
        {
            IEnumerable<T> elements = null;
            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    elements = await response.Content.ReadAsAsync<IEnumerable<T>>();
                }
            }
            catch (Exception) {
            }
            return elements;
        }
        /// <summary>
        /// Асинхронное получение элемента от сервиса
        /// </summary>
        /// <typeparam name="T">Тип элемента</typeparam>
        /// <param name="path">Ссылка.</param>
        /// <returns>Элемент.</returns>
        static async Task <T> GetElementAsync<T>(string path)
        {
            T element = default(T);
            try
            {
                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    element = await response.Content.ReadAsAsync<T>();
                }
            }
            catch (Exception)
            {
            }
            return element;
        }
        /// <summary>
        /// Добавление элемента в базу.
        /// </summary>
        /// <typeparam name="T">Тип элемента.</typeparam>
        /// <param name="element">Элемент.</param>
        /// <param name="path">Путь.</param>
        void AddElement<T> (T element, string path)
        {
            HttpResponseMessage response = client.PostAsJsonAsync<T>(path, element).Result;
            if (response.IsSuccessStatusCode)
            {
                LoadData();
            }
        }
    }
}
