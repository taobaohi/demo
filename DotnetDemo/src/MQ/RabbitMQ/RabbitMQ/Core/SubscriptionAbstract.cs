using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQDemo.Core
{
    public abstract class SubscriptionAbstract
    {

        protected string ExchangeName { get; set; }
        protected string AddRoutingKey { get; set; }
        protected string ModifyRoutingKey { get; set; }
        protected string DeleteRoutingKey { get; set; }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="serviceFunc"></param>
        /// <param name="channel"></param>
        /// <param name="exchangeName"></param>
        /// <param name="routingKey"></param>
        protected void Subscription(Action<string> serviceFunc, IModel channel, string exchangeName, string routingKey)
        {
            // var queueHead = ConfigurationManager.AppSettings["queue_head"];
            // 声明Exchange
            channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false);
            // 声明Queue:{queueHead}.
            var queueName = channel.QueueDeclare($"{exchangeName}.{routingKey}", true, false, false).QueueName;
            // 绑定Queue
            channel.QueueBind(queueName, exchangeName, routingKey);
            // 订阅类
            var sub = new global::RabbitMQ.Client.MessagePatterns.Subscription(channel, queueName, false);
            foreach (BasicDeliverEventArgs ea in sub)
            {
                var bodyStr = string.Empty;
                try
                {
                    var bodyBytes = ea.Body;
                    if (null != ea.BasicProperties.ContentEncoding)
                    {
                        bodyStr = Encoding.GetEncoding(ea.BasicProperties.ContentEncoding).GetString(bodyBytes);
                    }
                    else
                    {
                        bodyStr = Encoding.UTF8.GetString(bodyBytes);
                    }
                    // 委托函数 Action<string>
                    serviceFunc(bodyStr);
                }
                catch (Exception e)
                {
                    // 要有降级方案

                    //Logger.Info($"接收数据解析错误.\n\t{bodyStr}\n\t{e.Message}");
                    //Logger.Error(e);
                    //sub.Ack(ea);
                }
                finally
                {
                    sub.Ack(ea);
                }
            }
        }

        public void AddSubscriptionAsync(IModel channel, string exchangeName = null, string routingKey = null)
        {
            Task.Run(() =>
            {
                if (null == exchangeName) exchangeName = ExchangeName;
                if (null == routingKey) routingKey = AddRoutingKey;
                Subscription(Add, channel, exchangeName, routingKey);
            });
        }

        public void ModifySubscriptionAsync(IModel channel, string exchangeName = null, string routingKey = null)
        {
            Task.Run(() =>
            {
                if (null == exchangeName) exchangeName = ExchangeName;
                if (null == routingKey) routingKey = ModifyRoutingKey;
                Subscription(Modify, channel, exchangeName, routingKey);
            });
        }

        public void DeleteSubscriptionAsync(IModel channel, string exchangeName = null, string routingKey = null)
        {
            Task.Run(() =>
            {
                if (null == exchangeName) exchangeName = ExchangeName;
                if (null == routingKey) routingKey = DeleteRoutingKey;
                Subscription(Delete, channel, exchangeName, routingKey);
            });
        }

        protected abstract void Add(string json);

        protected abstract void Modify(string json);

        protected abstract void Delete(string json);

        protected T Deserialization<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
