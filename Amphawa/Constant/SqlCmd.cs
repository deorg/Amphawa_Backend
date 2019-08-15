using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amphawa.Constant
{
    public static class SqlCmd
    {
        public static class AMP010
        {
            public const string getAll = "select cate_id, cate_name from amp010";
            public const string getById = "select cate_id, cate_name from amp010 where cate_id = :cate_id";
            public const string add = "insert into amp010(cate_id, cate_name) values(:cate_id, :cate_name)";
            public const string update = "update amp010 set cate_id = :new_cate_id, cate_name = :new_cate_name where cate_id = :cate_id";
            public const string delete = "delete amp010 where cate_id = :cate_id";
        }
        public static class AMP020
        {
            public const string getAll = "select dept_id, dept_name from amp020 order by dept_id";
            public const string getById = "select dept_id, dept_name from amp020 where dept_id = :dept_id";
            public const string add = "insert into amp020(dept_id, dept_name) values(:dept_id, :dept_name)";
            public const string update = "update amp020 set dept_id = :new_dept_id, dept_name = :new_dept_name where dept_id = :dept_id";
            public const string delete = "delete amp020 where dept_id = :dept_id";
        }
        public static class AMP021
        {
            public const string getAll = "select dept_id, sect_id, sect_name from amp021";
            public const string getById = "select dept_id, sect_id, sect_name from amp021 where sect_id = :sect_id";
            public const string getByDept_id = "select dept_id, sect_id, sect_name from amp021 where dept_id = :dept_id";
            public const string add = "insert into amp021(dept_id, sect_id, sect_name) values(:dept_id, sect_id, sect_name)";
            public const string update = "update amp021 set dept_id = :new_dept_id, sect_id = :new_sect_id, sect_name = :new_sect_name where sect_id = :sect_id";
            public const string delete = "delete amp021 where sect_id = :sect_id";
        }
        public static class AMP030
        {
            public const string getAll = "select emp_id, emp_name from emp030";
            public const string getById = "select emp_id, emp_name from emp030 where emp_id = :emp_id";
            public const string add = "insert into amp030(emp_id, emp_name) values(:emp_id, emp_name)";
            public const string update = "update amp030 set emp_id = :new_emp_id, emp_name = :new_emp_name where emp_id = :emp_id";
            public const string delete = "delete amp030 where emp_id = :emp_id";
        }
        public static class AMP100
        {
            public const string getAll = "select job_id, job_date, job_desc, solution, dept_id, sect_id, device_no, created_by, created_time, job_status from amp100 order by job_date desc";
            public const string getById = "select job_id, job_date, job_desc, solution, dept_id, sect_id, device_no, created_by, created_time from amp100 where job_id = :job_id";
            public const string add = @"insert into amp100(job_date, job_desc, solution, dept_id, sect_id, device_no, created_by, job_status) 
                                           values(:job_date, :job_desc, :solution, :dept_id, :sect_id, :device_no, :created_by, :job_status) returning job_id into :job_id";
            public const string update = @"update amp100 set job_date = :job_date, job_desc = :job_desc, solution = :solution, dept_id = :dept_id, sect_id = :sect_id, device_no = :device_no, created_by = :created_by, job_status = :job_status
                                                     where job_id = :job_id";
            public const string delete = "delete amp100 where job_id = :job_id";
        }
        public static class AMP101
        {
            public const string getAll = "select job_id, cate_id from amp101";
            public const string getByJobId = "select job_id, cate_id from amp101 where job_id = :job_id";
            public const string getByCateId = "select job_id, cate_id from amp101 where cate_id = :cate_id";
            public const string add = "insert into amp101(job_id, cate_id) values(:job_id, :cate_id)";
            public const string updateByJobId = "update amp101 set job_id = :new_job_id, cate_id = :new_cate_id where :job_id";
            public const string updateByCateId = "update amp101 set job_id = :new_job_id, cate_id = :new_cate_id where :cate_id";
            public const string deleteByJobId = "delete amp101 where job_id = :job_id";
            public const string deleteByCateId = "delete amp101 where cate_id = :cate_id";
        }
    }
}