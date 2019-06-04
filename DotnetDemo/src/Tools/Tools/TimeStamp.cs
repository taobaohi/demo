using System;

namespace Tools
{
    /// <summary>
    /// UNIX时间转换
    /// </summary>
    public class TimeStamp
    {
        static byte timeZone = 8;
        static DateTime timeStart = new DateTime(1970, 1, 1, 0, 0, 0).AddHours(timeZone);

        /// <summary>
        /// 获取UTC0时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime dt)
        {
            return (long)((dt - timeStart).TotalMilliseconds);
        }

        /// <summary>
        /// 获取当前时区时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(long timeStamp) =>
            timeStart.AddTicks(timeStamp * 10000);

    }
}
