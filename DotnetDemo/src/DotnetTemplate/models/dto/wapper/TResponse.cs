

namespace dotnetdemo.model.dto.wapper
{
    using dotnetdemo.enums;

    public class TResponse<TData>
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
        public TData data { get; set; }

        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <returns></returns>
        public string Tostring()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
    }
}
