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
        public IEnumerable<Department> GetDepartments()
        {
            return OrganisationDB.GetDepartmentsList();
        }
        /// <summary>
        /// Передача подразделения с определённым идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Подразделение.</returns>
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
    }
}
