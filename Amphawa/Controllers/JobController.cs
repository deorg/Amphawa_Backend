using Amphawa.Models.api;
using Amphawa.Models.table;
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

        #region Category
        [Route("api/category")]
        public IHttpActionResult GetCategories()
        {
            try
            {
                var result = _job.getCategories();
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/category")]
        public IHttpActionResult GetCategories(string cate_id)
        {
            try
            {
                var result = _job.getCategoryById(cate_id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/category/add")]
        public IHttpActionResult PostAddCategory([FromBody]AMP010 value)
        {
            try
            {
                var result = _job.addCategory(value);
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/category/update")]
        public IHttpActionResult PostUpdateCategory([FromBody]m_Category value)
        {
            try
            {
                var result = _job.updateCategory(value);
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/category/delete")]
        public IHttpActionResult GetDeleteCategory(string cate_id)
        {
            try
            {
                var result = _job.deleteCategory(cate_id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        #endregion

        #region Job
        [Route("api/job")]
        public IHttpActionResult GetAllJob()
        {
            try
            {
                var result = _job.getJob();
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/job")]
        public IHttpActionResult GetJobById(int job_id)
        {
            try
            {
                var result = _job.getJobById(job_id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/job/add")]
        public IHttpActionResult PostAddJob([FromBody]m_Job value)
        {
            try
            {
                var result = _job.addJob(value);
                if(result > 0)
                {                
                    if(value.cate_id != null)
                    {
                        m_JobGroup group = new m_JobGroup();
                        group.job_id = result;
                        group.cate_id = value.cate_id.ToArray();
                        var res = _job.addJobGroup(group);
                        return Ok(res);
                    }
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/job/update")]
        public IHttpActionResult PostUpdateJob([FromBody]AMP100 value)
        {
            try
            {
                var result = _job.updateJob(value);
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/job/delete")]
        public IHttpActionResult GetDeleteJob(int job_id)
        {
            try
            {
                var result = _job.deleteJobGroup(job_id);
                var res = _job.deleteJob(job_id);
                return Ok(res);
                //var result = _job.deleteJob(job_id);
                //if(result > 0)
                //{
                //    var res = _job.deleteJobGroup(job_id);
                //    return Ok(res);
                //}
                //return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        #endregion

        #region Job group
        [Route("api/job/group")]
        public IHttpActionResult GetJobGroup()
        {
            try
            {
                var result = _job.getJobGroup();
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/job/group")]
        public IHttpActionResult GetJobGroup(int job_id)
        {
            try
            {
                var result = _job.getJobGroupById(job_id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        #endregion
    }
}
