using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetdemo.model.dto.request
{
    public class UserDeleteRequest
    {
        public List<long> ids { get; set; }
    }
}
