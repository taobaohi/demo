using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C21.Bsp.DataTransmission.API.client.sis2koofang.models
{
    /// <summary>
    /// 
    /// </summary>
    public class KoofangResponse
    {
        /// <summary>
        /// 1000:更新表"change_record"字段"[handle_date],[create_date]"
        /// </summary>
        public int code { get; set; }
        public string mess { get; set; }
        public object data { get; set; }
    }
}
