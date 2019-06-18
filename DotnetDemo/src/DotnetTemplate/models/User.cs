using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetdemo.model
{
    public class User
    {
        /// <summary>
        /// id
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        ///  姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }
    }
}
