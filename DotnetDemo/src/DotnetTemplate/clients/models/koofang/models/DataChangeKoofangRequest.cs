using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C21.Bsp.DataTransmission.API.client.sis2koofang.models
{
    /// <summary>
    /// 数据改变通知
    /// 小区、小区图片、房源、房源图片
    /// </summary>
    public class DataChangeKoofangRequest
    {
        public long falgId { get; set; }
        public string area { get; set; }
        public long id { get; set; }
        public string action { get; set; }
    }
}
