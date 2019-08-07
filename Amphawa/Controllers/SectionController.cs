using Amphawa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Amphawa.Controllers
{
    public class SectionController : ApiController
    {
        Section _sect = new Section();

        [Route("api/section")]
        public IHttpActionResult GetSection()
        {
            try
            {
                var result = _sect.getSect();
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/section")]
        public IHttpActionResult GetSection(string sect_id)
        {
            try
            {
                var result = _sect.getSectById(sect_id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/section/dept")]
        public IHttpActionResult GetSectionByDept(string dept_id)
        {
            try
            {
                var result = _sect.getSectByDeptId(dept_id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
