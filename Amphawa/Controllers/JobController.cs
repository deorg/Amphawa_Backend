using Amphawa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Amphawa.Controllers
{
    public class JobController : ApiController
    {
        Job _job = new Job();

        [Route("api/categories")]
        public IHttpActionResult GetCategories()
        {
            try
            {
                var result = _job.GetCategories();
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/categories")]
        public IHttpActionResult GetCategories(string cate_id)
        {
            try
            {
                var result = _job.GetCategories();
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
