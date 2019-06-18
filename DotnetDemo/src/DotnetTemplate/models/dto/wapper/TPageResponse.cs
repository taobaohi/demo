
using System.Collections.Generic;

namespace dotnetdemo.model.dto.wapper
{
    using dotnetdemo.enums;
    using dotnetdemo.model.dto.comm;

    public class TPageResponse<TData>
    {

        /// <summary>
        /// 返回代码
        /// </summary>
        public CodeEnum code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 通用返回数据
        /// </summary>
        public IEnumerable<TData> dataList { get; set; }

        /// <summary>
        /// 分页数据
        /// </summary>
        public PageInfoResponse pageData { get; set; }

    }
}
