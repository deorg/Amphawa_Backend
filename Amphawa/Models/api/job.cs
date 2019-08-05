using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amphawa.Models.api
{
    public class m_Job
    {
        public int job_id { get; set; }
        public DateTime? job_date { get; set; }
        public string job_desc { get; set; }
        public string solution { get; set; }
        public string dept_id { get; set; }
        public string sect_id { get; set; }
        public string device_no { get; set; }
        public List<string> cate_id { get; set; }
        public string created_by { get; set; }
        public DateTime? created_time { get; set; }
    }
}