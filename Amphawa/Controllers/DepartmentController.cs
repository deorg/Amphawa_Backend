using Amphawa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Amphawa.Controllers
{
    public class DepartmentController : ApiController
    {
        Department _dept = new Department();

        [Route("api/department")]
        public IHttpActionResult GetDepartment()
        {
            try
            {
                var result = _dept.getDept();
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/department")]
        public IHttpActionResult GetDepartment(string dept_id)
        {
            try
            {
                var result = _dept.getDeptById(dept_id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
