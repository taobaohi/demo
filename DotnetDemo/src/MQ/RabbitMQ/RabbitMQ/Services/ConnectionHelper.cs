using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQDemo.Services
{
    public enum SystemEnum
    {
        HCIS_HR,
        TMS,
        SIS,
        HCIS_Employee,
        UnityAccount,
        SMS
    }

    public static class ConnectionHelper
    {
        private static readonly object Locker = new object();

        private static IConnection HcisHrConn { get; set; }
        private static IConnection TmsConn { get; set; }
        private static IConnection SisConn { get; set; }
        private static IConnection HcisEmployeeConn { get; set; }
        private static IConnection UnityAccountConn { get; set; }
        private static IConnection SMSConn { get; set; }

        private static void CreateConnection(string uri, SystemEnum systemEnum)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(uri),
                RequestedHeartbeat = 60,
                AutomaticRecoveryEnabled = true
            };
            var conn = factory.CreateConnection("sis_subscription_service");
            conn.ConnectionShutdown += RabbitMqConnectionShutdownEvent;

            switch (systemEnum)
            {
                case SystemEnum.HCIS_HR:
                    HcisHrConn = conn;
                    break;

                case SystemEnum.TMS:
                    TmsConn = conn;
                    break;

                case SystemEnum.SIS:
                    SisConn = conn;
                    break;

                case SystemEnum.HCIS_Employee:
                    HcisEmployeeConn = conn;
                    break;

                case SystemEnum.UnityAccount:
                    UnityAccountConn = conn;
                    break;
                case SystemEnum.SMS:
                    SMSConn = conn;
                    break;
            }
        }

        private static void RabbitMqConnectionShutdownEvent(object sender, ShutdownEventArgs e)
        {
            throw new Exception("RabbitMQ connection was disconnected!");
        }

        public static IConnection GetConnection(string uri, SystemEnum systemEnum)
        {
            switch (systemEnum)
            {
                case SystemEnum.HCIS_HR:
                    if (null == HcisHrConn || !HcisHrConn.IsOpen)
                        lock (Locker)
                        {
                            if (null == HcisHrConn || !HcisHrConn.IsOpen)
                                CreateConnection(uri, systemEnum);
                        }
                    return HcisHrConn;

                case SystemEnum.TMS:
                    if (null == TmsConn || !TmsConn.IsOpen)
                        lock (Locker)
                        {
                            if (null == TmsConn || !TmsConn.IsOpen)
                                CreateConnection(uri, systemEnum);
                        }
                    return TmsConn;

                case SystemEnum.SIS:
                    if (null == SisConn || !SisConn.IsOpen)
                        lock (Locker)
                        {
                            if (null == SisConn || !SisConn.IsOpen)
                                CreateConnection(uri, systemEnum);
                        }
                    return SisConn;

                case SystemEnum.HCIS_Employee:
                    if (null == HcisEmployeeConn || !HcisEmployeeConn.IsOpen)
                        lock (Locker)
                        {
                            if (null == HcisEmployeeConn || !HcisEmployeeConn.IsOpen)
                                CreateConnection(uri, systemEnum);
                        }
                    return HcisEmployeeConn;

                case SystemEnum.UnityAccount:
                    if (null == UnityAccountConn || !UnityAccountConn.IsOpen)
                        lock (Locker)
                        {
                            if (null == UnityAccountConn || !UnityAccountConn.IsOpen)
                                CreateConnection(uri, systemEnum);
                        }
                    return UnityAccountConn;
                case SystemEnum.SMS:
                    if (null == SMSConn || !SMSConn.IsOpen)
                        lock (Locker)
                        {
                            if (null == SMSConn || !SMSConn.IsOpen)
                                CreateConnection(uri, systemEnum);
                        }
                    return SMSConn;
                default:
                    return null;
            }
        }

        public static string GetConnectionString(SystemEnum systemEnum)
        {
            //var app_status = ConfigurationManager.AppSettings["application_status"];

            //switch (systemEnum)
            //{
            //    case SystemEnum.HCIS_HR:
            //        return ConfigurationManager.AppSettings[$"{app_status}_hcis_mq_uri"];

            //    case SystemEnum.TMS:
            //        return ConfigurationManager.AppSettings[$"{app_status}_tms_mq_uri"];

            //    case SystemEnum.SIS:
            //        return ConfigurationManager.AppSettings[$"{app_status}_sis_mq_uri"];

            //    case SystemEnum.HCIS_Employee:
            //        return ConfigurationManager.AppSettings[$"{app_status}_hcis_Employee_mq_uri"];

            //    case SystemEnum.UnityAccount:
            //        return ConfigurationManager.AppSettings[$"{app_status}_UnityAccount_uri"];
            //    case SystemEnum.SMS:
            //        return ConfigurationManager.AppSettings[$"{app_status}_sms_mq_uri"];
            //    default:

                    return null;
            }


        /// <summary>
        /// 服务发现
        /// </summary>
        /// <param name="systemEnum"></param>
        /// <returns></returns>
        public static IModel GetChannel(SystemEnum systemEnum)
        {
            var connectionUri = GetConnectionString(systemEnum);
            var conn = GetConnection(connectionUri, systemEnum);
            var channel = conn?.CreateModel();
            return channel;
        }
    
    }
}
