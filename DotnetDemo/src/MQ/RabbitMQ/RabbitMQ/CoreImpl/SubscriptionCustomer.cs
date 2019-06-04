using RabbitMQDemo.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQDemo.Impl
{
    /// <summary>
    /// 客源订阅
    /// </summary>
    public class SubscriptionCustomer : SubscriptionAbstract
    {
        protected override void Add(string json)
        {
            throw new NotImplementedException();
        }

        protected override void Delete(string json)
        {
            throw new NotImplementedException();
        }

        protected override void Modify(string json)
        {
            throw new NotImplementedException();
        }
    }
}
