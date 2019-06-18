﻿using System.ComponentModel;

namespace dotnetdemo.enums
{
    public enum CodeEnum
    {
        [Description("成功")]
        Success = 200,
        [Description("程序执行错误")]
        Error = 500,
    };
}
