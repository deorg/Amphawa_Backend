using Amphawa.Models.table;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Amphawa.Services
{
    public class Department
    {
        private const string _connStr = Constant.Database.Production.Connstring;

        public List<AMP020> getDept()
        {
            using (var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP020.getAll, conn) { CommandType = CommandType.Text })
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<AMP020> data = new List<AMP020>();
                            while (reader.Read())
                            {
                                data.Add(new AMP020
                                {
                                    dept_id = reader[0].ToString(),
                                    dept_name = reader[1].ToString()
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
                    Console.WriteLine($"Get dept error => {e.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
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
                                dept_id = reader[0].ToString(),
                                dept_name = reader[1].ToString()
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
                    Console.WriteLine($"Get dept by id error => {e.Message}");
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