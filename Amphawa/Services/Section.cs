using Amphawa.Models.table;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Amphawa.Services
{
    public class Section
    {
        private const string _connStr = Constant.Database.Production.Connstring;

        public List<AMP021> getSect()
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP021.getAll, conn) { CommandType = CommandType.Text })
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<AMP021> data = new List<AMP021>();
                            while (reader.Read())
                            {
                                data.Add(new AMP021
                                {
                                    dept_id = reader[0].ToString(),
                                    sect_id = reader[1].ToString(),
                                    sect_name = reader[2].ToString()
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
                    Console.WriteLine($"Get sect error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
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
                                dept_id = reader[0].ToString(),
                                sect_id = reader[1].ToString(),
                                sect_name = reader[2].ToString()
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
                    Console.WriteLine($"Get sect by id error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public List<AMP021> getSectByDeptId(string dept_id)
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP021.getByDept_id, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("dept_id", dept_id);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<AMP021> data = new List<AMP021>();
                            while (reader.Read())
                            {
                                data.Add(new AMP021
                                {
                                    dept_id = reader[0].ToString(),
                                    sect_id = reader[1].ToString(),
                                    sect_name = reader[2].ToString()
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
                    Console.WriteLine($"Get sect by id error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}