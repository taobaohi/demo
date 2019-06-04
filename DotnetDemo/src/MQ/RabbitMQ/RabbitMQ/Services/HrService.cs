using RabbitMQDemo.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQDemo.Services
{
    public class HrService
    {
        public bool start()
        {
            var hrSub = new SubscriptionHr();
            for (int i = 0; i < 8; i++)
            {
                hrSub.AddSubscriptionAsync(ConnectionHelper.GetChannel(SystemEnum.HCIS_Employee));
                hrSub.ModifySubscriptionAsync(ConnectionHelper.GetChannel(SystemEnum.HCIS_Employee));
            }
            return false;
        }
    }
}
