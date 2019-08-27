using Amphawa.Models.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Amphawa.Models.api;

namespace Amphawa.Services
{
    public class Job
    {
        private const string _connStr = Constant.Database.Development.Connstring;

        #region Category
        public List<AMP010> getCategories()
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP010.getAll, conn) { CommandType = CommandType.Text })
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<AMP010> data = new List<AMP010>();
                            while (reader.Read())
                            {
                                data.Add(new AMP010
                                {
                                    cate_id = reader["CATE_ID"].ToString(),
                                    cate_name = reader["CATE_NAME"].ToString()
                                });
                            }
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        cmd.Dispose();
                        reader.Dispose();
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get categories error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public AMP010 getCategoryById(string cate_id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP010.getById, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("cate_id", cate_id);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            //List<AMP010> data = new List<AMP010>();
                            reader.Read();
                            AMP010 data = new AMP010
                            {
                                cate_id = reader["CATE_ID"].ToString(),
                                cate_name = reader["CATE_NAME"].ToString()
                            };
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        cmd.Dispose();
                        reader.Dispose();
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get category by id error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int addCategory(AMP010 value)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP010.add, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("cate_id", value.cate_id);
                        cmd.Parameters.Add("cate_name", value.cate_name);
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return result;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Add category by id error => {e.Message}");
                    return 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int updateCategory(m_Category value)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP010.update, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("new_cate_id", value.new_cate_id);
                        cmd.Parameters.Add("new_cate_name", value.new_cate_name);
                        cmd.Parameters.Add("cate_id", value.cate_id);
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return result;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Update category by id error => {e.Message}");
                    return 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int deleteCategory(string id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP010.delete, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("cate_id", id);
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return result;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Add category by id error => {e.Message}");
                    return 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        #endregion

        #region Job
        public List<m_Job> getJob()
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP100.getAll, conn) { CommandType = CommandType.Text })
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<m_Job> data = new List<m_Job>();
                            while (reader.Read())
                            {
                                data.Add(new m_Job
                                {
                                    job_id = reader.GetInt32(0),
                                    job_date = reader[1] == DBNull.Value ? null : (DateTime?)reader.GetDateTime(1),
                                    job_desc = reader[2] == DBNull.Value ? string.Empty : reader.GetString(2),
                                    solution = reader[3] == DBNull.Value ? string.Empty : reader.GetString(3),
                                    dept_id = reader[4] == DBNull.Value ? string.Empty : getDeptById(reader.GetString(4)).dept_id + " " + getDeptById(reader.GetString(4)).dept_name,
                                    sect_id = reader[5] == DBNull.Value ? string.Empty : getSectById(reader.GetString(5)).sect_id + " " + getSectById(reader.GetString(5)).sect_name,
                                    device_no = reader[6] == DBNull.Value ? string.Empty : reader.GetString(6),
                                    created_by = reader[7] == DBNull.Value ? string.Empty : reader.GetString(7),
                                    created_time = reader[8] == DBNull.Value ? null : (DateTime?)reader.GetDateTime(8),
                                    job_status = reader[9] == DBNull.Value ? string.Empty : reader.GetString(9)
                                });
                            }
                            foreach(var j in data)
                            {
                                data[data.IndexOf(j)].cate_id = getJobGroupById(j.job_id);
                            }
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        cmd.Dispose();
                        reader.Dispose();
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get Jobs error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public AMP100 getJobById(int job_id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP100.getById, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("job_id", job_id);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            AMP100 data = new AMP100
                            {
                                job_id = reader.GetInt32(0),
                                job_date = reader[1] == DBNull.Value ? null : (DateTime?)reader.GetDateTime(1),
                                job_desc = reader[2] == DBNull.Value ? string.Empty : reader.GetString(2),
                                solution = reader[3] == DBNull.Value ? string.Empty : reader.GetString(3),
                                dept_id = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4) + " " + getDeptById(reader.GetString(4)),
                                sect_id = reader[5] == DBNull.Value ? string.Empty : reader.GetString(5),
                                device_no = reader[6] == DBNull.Value ? string.Empty : reader.GetString(6),
                                created_by = reader[7] == DBNull.Value ? string.Empty : reader.GetString(7),
                                created_time = reader[8] == DBNull.Value ? null : (DateTime?)reader.GetDateTime(8),
                                job_status = reader[9] == DBNull.Value ? string.Empty : reader.GetString(9)
                            };
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        cmd.Dispose();
                        reader.Dispose();
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get category by id error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int addJob(m_Job value)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP100.add, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("job_date", value.job_date);
                        cmd.Parameters.Add("job_desc", value.job_desc);
                        cmd.Parameters.Add("solution", value.solution);
                        cmd.Parameters.Add("dept_id", value.dept_id);
                        cmd.Parameters.Add("sect_id", value.sect_id);
                        cmd.Parameters.Add("device_no", value.device_no);
                        cmd.Parameters.Add("created_by", value.created_by);
                        cmd.Parameters.Add("job_status", value.job_status);
                        cmd.Parameters.Add(new OracleParameter { ParameterName = ":job_id", OracleDbType = OracleDbType.Int32, Direction = ParameterDirection.Output});
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return Int32.Parse(cmd.Parameters[":job_id"].Value.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Add job by id error => {e.Message}");
                    return 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int updateJob(m_Job value)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP100.update, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("job_date", value.job_date);
                        cmd.Parameters.Add("job_desc", value.job_desc);
                        cmd.Parameters.Add("solution", value.solution);
                        cmd.Parameters.Add("dept_id", value.dept_id);
                        cmd.Parameters.Add("sect_id", value.sect_id);
                        cmd.Parameters.Add("device_no", value.device_no);
                        cmd.Parameters.Add("created_by", value.created_by);
                        cmd.Parameters.Add("job_status", value.job_status);
                        cmd.Parameters.Add("job_id", value.job_id);
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return result;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Update job by id error => {e.Message}");
                    return 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int deleteJob(int job_id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP100.delete, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("job_id", job_id);
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return result;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Update job by id error => {e.Message}");
                    return 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        #endregion

        #region Job group
        public List<AMP101> getJobGroup()
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP101.getAll, conn) { CommandType = CommandType.Text })
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<AMP101> data = new List<AMP101>();
                            while (reader.Read())
                            {
                                data.Add(new AMP101
                                {
                                    job_id = reader.GetInt32(0),
                                    cate_id = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1)
                                });
                            }
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        cmd.Dispose();
                        reader.Dispose();
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get Jobs group error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public List<string> getJobGroupById(int job_id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP101.getByJobId, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("job_id", job_id);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<string> data = new List<string>();
                            while (reader.Read())
                            {
                                data.Add(reader[1] == DBNull.Value ? string.Empty : getCategoryById(reader.GetString(1)).cate_name);
                            }
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        cmd.Dispose();
                        reader.Dispose();
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get Jobs group error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int addJobGroup(m_JobGroup value)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP101.add, conn) { CommandType = CommandType.Text })
                    {
                        int count = 0;
                        foreach(var j in value.cate_id)
                        {
                            cmd.Parameters.Add("job_id", value.job_id);
                            cmd.Parameters.Add("cate_id", j);
                            count += cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        cmd.Dispose();
                        return count;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Add job group by id error => {e.Message}");
                    return 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public int deleteJobGroup(int job_id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP101.deleteByJobId, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("job_id", job_id);
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return result;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Delete job group by id error => {e.Message}");
                    return 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        #endregion

        #region Department
        public AMP020 getDeptById(string dept_id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP020.getById, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("dept_id", dept_id);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            AMP020 data = new AMP020
                            {
                                dept_id = reader.GetString(0),
                                dept_name = reader.GetString(1)
                            };
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        cmd.Dispose();
                        reader.Dispose();
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get category by id error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        #endregion

        #region Section
        public AMP021 getSectById(string sect_id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP021.getById, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("sect_id", sect_id);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            AMP021 data = new AMP021
                            {
                                dept_id = reader.GetString(0),
                                sect_id = reader.GetString(1),
                                sect_name = reader.GetString(2)
                            };
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        cmd.Dispose();
                        reader.Dispose();
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get category by id error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        #endregion
    }
}