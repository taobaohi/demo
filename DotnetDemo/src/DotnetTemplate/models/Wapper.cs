using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace dotnetdemo.model
{

    public enum CodeEnum
    {
        [Description("成功")]
        Success = 200,
        [Description("程序执行错误")]
        Error = 500,
    };

    public static class Extension
    {
        public static string Description(this CodeEnum myEnum)
        {
            Type type = typeof(CodeEnum);
            FieldInfo info = type.GetField(myEnum.ToString());
            DescriptionAttribute descriptionAttribute = info.GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                return descriptionAttribute.Description;
            }
            else
            {
                return type.ToString();
            }
        }
    }

    public class Wapper
    {
        public class OutputT<TData>
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
}
