using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetdemo.model.dto.request
{
    public class UserFilterRequest
    {
        /// <summary>
        ///  姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string phone { get; set; }
    }
}
