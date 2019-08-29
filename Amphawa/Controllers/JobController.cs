using Amphawa.Models.api;
using Amphawa.Models.table;
using Amphawa.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
                        return Ok(result);
                    }
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/job/photo/add")]
        public IHttpActionResult PostPhotos()
        {
            int res = 0;
            try
            {
                var files = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files : null;
                if (files != null)
                {
                    List<AMP102> images = new List<AMP102>();
                    for (int i = 0; i<files.Count; i++)
                    {
                        var fileName = Path.GetFileName(files[i].FileName);
                        var job_id = fileName.Split('_').First();
                        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/images/jobs"), fileName);
                        files[i].SaveAs(path);
                        images.Add(new AMP102 { job_id = Int32.Parse(job_id), img_name = fileName, img_url = $"http://35.240.167.23/images/jobs/{fileName}" });
                    }
                    if(images.Count > 0)
                    {
                        res = _job.addImage(images);
                        Console.WriteLine("up load photo => " + res);
                    }                   
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("error => " + e.Message);
            }
            return Ok(res);
        }
        [Route("api/job/photo/delete")]
        public IHttpActionResult GetDeletePhoto(string photo)
        {
            try
            {
                var result = _job.deleteImagesByName(photo);
                if (result > 0)
                {
                    var file = new FileInfo(Path.Combine(HttpContext.Current.Server.MapPath("~/images/jobs"), photo));
                    if (file.Exists)
                    {
                        file.Delete();
                        return Ok("deleted");
                    }
                    else
                        return BadRequest("file not exist");
                }
                else
                    return BadRequest("not found image");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("api/job/update")]
        public IHttpActionResult PostUpdateJob([FromBody]m_Job value)
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
                var resJobGroup = _job.deleteJobGroup(job_id);
                var resPhoto = _job.deleteImagesByJobId(job_id);
                var res = _job.deleteJob(job_id);
                return Ok(res);
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
