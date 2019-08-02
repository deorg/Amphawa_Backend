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
            public const string getAllCategory = "select cate_id, cate_name from amp010";
            public const string getCategoryById = "select cate_id, cate_name from amp010 where cate_id = :cate_id";
            public const string addCategory = "insert into amp010(cate_id, cate_name) values(:cate_id, :cate_name)";
            public const string updateByCateId = "update amp010 set cate_id = :new_cate_id, new_cate_name = :cate_name where cate_id = :cate_id";
            public const string deleteByCateId = "delete amp010 where cate_id = :cate_id";
        }
        public static class AMP020
        {
            public const string getAllDepartment = "select dept_id, dept_name from amp020";
            public const string getDepartmentById = "select dept_id, dept_name from amp020 where dept_id = :dept_id";
            public const string addDepartment = "insert into amp020(dept_id, dept_name) values(:dept_id, :dept_name)";
            public const string updateByDeptId = "update amp020 set dept_id = :new_dept_id, dept_name = :new_dept_name where dept_id = :dept_id";
            public const string deleteByDeptId = "delete amp020 where dept_id = :dept_id";
        }
        public static class AMP021
        {
            public const string getAllSection = "select dept_id, sect_id, sect_name from amp021";
            public const string getSectionByDeptId = "select dept_id, sect_id, sect_name where dept_id = :dept_id";
            public const string getSectionBySectionId = "select dept_id, sect_id, sect_name where sect_id = :sect_id";
            public const string addSection = "insert into amp021(dept_id, sect_id, sect_name) values(:dept_id, sect_id, sect_name)";
            public const string updateByDeptId = "update amp021 set dept_id = :new_dept_id, sect_id = :new_sect_id, sect_name = :new_sect_name where dept_id = :dept_id";
            public const string updateBYSectId = "update amp021 set dept_id = :new_dept_id, sect_id = :new_sect_id, sect_name = :new_sect_name where sect_id = :sect_id";
            public const string deleteByDeptId = "delete amp021 where dept_id = :dept_id";
            public const string deleteBySectId = "delete amp021 where sect_id = :sect_id";
        }
        public static class AMP030
        {
            public const string getAllEmployee = "select emp_id, emp_name from emp030";
            public const string getEmployeeById = "select emp_id, emp_name from emp030 where emp_id = :emp_id";
            public const string addEmployee = "insert into amp030(emp_id, emp_name) values(:emp_id, emp_name)";
            public const string updateEmployeeByEmpId = "update amp030 set emp_id = :new_emp_id, emp_name = :new_emp_name where emp_id = :emp_id";
            public const string deleteByEmpId = "delete amp030 where emp_id = :emp_id";
        }
        public static class AMP100
        {
            public const string getAllJob = "select job_id, job_date, job_desc, solution, dept_id, sect_id, device_no, created_by, created_time from amp100";
            public const string getJobByJobId = "select job_id, job_date, job_desc, solution, dept_id, sect_id, device_no, created_by, created_time from amp100 where job_id = :job_id";
            public const string addJob = @"insert into amp100(job_date, job_desc, solution, dept_id, sect_id, device_no, created_by) 
                                           values(:job_date, :job_desc, :solution, :dept_id, :sect_id, :device_no, :created_by)";
            public const string updateJobByJobId = @"update amp100 set job_date = :job_date, job_desc = :job_desc, solution = :solution, dept_id = :dept_id, sect_id = :sect_id, device_no = :device_no, created_by = :created_by
                                                     where job_id = :job_id";
            public const string deleteJobByJobId = "delete amp100 where job_id = :job_id";
        }
        public static class AMP101
        {
            public const string getAllJobCategory = "select job_id, cate_id from amp101";
            public const string getJobCategoryByJobId = "select job_id, cate_id from amp101 where job_id = :job_id";
            public const string getJobCategoryByCateId = "select job_id, cate_id from amp101 where cate_id = :cate_id";
            public const string addJobCategory = "insert into amp101(job_id, cate_id) values(:job_id, :cate_id)";
            public const string updateJobCategoryByJobId = "update amp101 set job_id = :new_job_id, cate_id = :new_cate_id where :job_id";
            public const string updateJobCategoryByCateId = "update amp101 set job_id = :new_job_id, cate_id = :new_cate_id where :cate_id";
            public const string deleteJobCategoryByJobId = "delete amp101 where job_id = :job_id";
            public const string deleteJobCategoryByCateId = "delete amp101 where cate_id = :cate_id";
        }
    }
}