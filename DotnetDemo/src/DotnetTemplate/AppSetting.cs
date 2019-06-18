using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetdemo
{
    public class AppSetting
    {
       public ConnectionStrings connectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string MySqlDemo { get; set; }
        public string MsSqlDemo { get; set; }
        public string RedisDemo { get; set; }
    }
}
