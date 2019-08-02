using Amphawa.Models.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Amphawa.Services
{
    public class Job
    {
        private const string _connStr = Constant.Database.Development.Connstring;

        #region Category
        public List<Category> GetCategories()
        {
            using(var conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constant.SqlCmd.AMP010.getAllCategory, conn) { CommandType = CommandType.Text })
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<Category> data = new List<Category>();
                            while (reader.Read())
                            {
                                data.Add(new Category
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
                catch(Exception e)
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
        #endregion
    }
}