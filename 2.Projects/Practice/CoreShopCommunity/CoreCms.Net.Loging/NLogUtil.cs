using NLog;
using System.ComponentModel;

namespace CoreCms.Net.Loging
{
    public enum LogType
    {
        [Description("网站")]
        Web,

        [Description("数据库")]
        DataBase,

        [Description("Api接口")]
        ApiRequest,

        [Description("中间件")]
        Middleware,

        [Description("其他")]
        Other,

        [Description("Swagger")]
        Swagger,

        [Description("定时任务")]
        Task,

        [Description("订单")]
        Order,

        [Description("订单退款")]
        Refund,

        [Description("退款结果通知")]
        RefundResultNotification,

        [Description("Redis消息队列")]
        RedisMessageQueue,

        [Description("微信推送消息")]
        WxPost,
    }

    public static class NLogUtil
    {
        private static readonly Logger FileLogger = LogManager.GetLogger("logfile");

        /// <summary>
        /// 写日志到文件
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logTitle">标题（255字符）</param>
        /// <param name="message">信息</param>
        /// <param name="exception">异常</param>
        public static void WriteFileLog(LogLevel logLevel, LogType logType, string logTitle, string message, Exception exception = null)
        {
            LogEventInfo theEvent = new LogEventInfo(logLevel, FileLogger.Name, message);
            theEvent.Properties["LogType"] = logType.ToString();
            theEvent.Properties["LogTitle"] = logTitle;
            theEvent.Exception = exception;
            FileLogger.Log(theEvent);
        }

        /// <summary>
        /// 同时写入到日志到数据库和文件
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logTitle">标题（255字符）</param>
        /// <param name="message">信息</param>
        /// <param name="exception">异常</param>
        public static void WriteAll(LogLevel logLevel, LogType logType, string logTitle, string message, Exception exception = null)
        {
            //先存文件
            WriteFileLog(logLevel, logType, logTitle, message, exception);
        }
    }
}