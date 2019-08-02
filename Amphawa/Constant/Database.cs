using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amphawa.Constant
{
    public static class Database
    {
        public static class Development
        {
            public const string Connstring = "User Id=amphawa;Password=amphawa;Data Source=35.240.167.23:1521/AORCL;";
            public const string Host = "35.240.167.23";
            public const string Port = "1521";
            public const string Source = "AORCL";
            public const string Username = "AMPHAWA";
            public const string Password = "AMPHAWA";
        }
        public static class Production
        {
            public const string Connstring = "User Id=amphawa;Password=amphawa;Data Source=localhost:1521/AORCL;";
            public const string Host = "localhost";
            public const string Port = "1521";
            public const string Source = "AORCL";
            public const string Username = "AMPHAWA";
            public const string Password = "AMPHAWA";
        }
    }
}