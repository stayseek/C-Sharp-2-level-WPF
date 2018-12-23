using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using C_Sharp_WPF_WebAPI.Models;

namespace C_Sharp_WPF_WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        /// <summary>
        /// Передача списка сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return OrganisationDB.GetEmployeesList();
        }
        /// <summary>
        /// Передача сотрудника с определённым идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Сотрудник.</returns>
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = OrganisationDB.GetEmployeeWithId(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
    }
}
