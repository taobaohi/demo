using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace helper
{
    public class ClientRequestHepler
    {
        public static string PostJson(string url, object obj)
        {
            try
            {
                var msg = url.PostJsonAsync(obj);
                msg.Wait();
                var str = msg.Result.Content.ReadAsStringAsync();
                str.Wait();
                return str.Result;
            }
            catch(Exception ex)
            {
                // “url”和“obj”无法返回“服务消费者”
                return null;
            }
        }
    }
}
