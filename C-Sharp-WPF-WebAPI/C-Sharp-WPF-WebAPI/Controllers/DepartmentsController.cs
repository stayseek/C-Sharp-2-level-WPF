using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using C_Sharp_WPF_WebAPI.Models;

namespace C_Sharp_WPF_WebAPI.Controllers
{
    public class DepartmentsController : ApiController
    {
        /// <summary>
        /// Передача списка подразделений.
        /// </summary>
        /// <returns>Список подразделений.</returns>
        [Route("getdepartments")]
        public IEnumerable<Department> GetDepartments()
        {
            return OrganisationDB.GetDepartmentsList();
        }
        /// <summary>
        /// Передача подразделения с определённым идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Подразделение.</returns>
        [Route("getdepartments/{id}")]
        public IHttpActionResult GetDepartment(int id)
        {
            var department = OrganisationDB.GetDepartmentWithId(id);
            if (department == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(department);
            }
        }
        /// <summary>
        /// Получение подразделения на создание.
        /// </summary>
        /// <param name="value">Подразделение.</param>
        /// <returns>Результат добавления.</returns>
        [Route("adddepartment")]
        public HttpResponseMessage Post([FromBody]Department value)
        {
            if (OrganisationDB.AddDepartment(value))
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
