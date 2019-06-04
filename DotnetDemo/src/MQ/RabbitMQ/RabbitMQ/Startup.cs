using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQDemo
{
    public class Startup
    {
        public Startup()
        {

        }
        /// <summary>
        /// 依赖注入
        /// </summary>
        public static ServiceProvider DependencyInjection()
        {
            var serviceProvider = new ServiceCollection()
          //.AddTransient<IHttpClient, HttpClientlmpl>()
          //.AddTransient<IBeiFileService, BeiFileService>()
          //.AddTransient<IBeiDictionaryService, BeiDictionaryService>()
          //.AddTransient<IHouseService, HouseService>()
          //.AddTransient<IHouseImageService, HouseImageService>()
          //.AddTransient<IHdicCommunityService, HdicCommunityService>()
          //.AddTransient<IHdicCommunityImageService, HdicCommunityImageService>()
          //.AddTransient<IBeiMQSendJsonService, BeiMQSendJsonService>()
          .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
