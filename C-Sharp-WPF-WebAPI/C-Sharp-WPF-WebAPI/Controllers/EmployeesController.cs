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
        [Route("getemployees")]
        public IEnumerable<Employee> GetEmployees()
        {
            return OrganisationDB.GetEmployeesList();
        }
        /// <summary>
        /// Передача сотрудника с определённым идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Сотрудник.</returns>
        [Route("getemployees/{id}")]
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
        /// <summary>
        /// Получение сотрудника на создание.
        /// </summary>
        /// <param name="value">Сотрудник.</param>
        /// <returns>Результат добавления.</returns>
        [Route("addemployee")]
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            if (OrganisationDB.AddEmployee(value))
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
