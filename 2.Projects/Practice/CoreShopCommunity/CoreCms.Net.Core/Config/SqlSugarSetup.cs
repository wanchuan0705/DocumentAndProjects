using CoreCms.Net.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar.IOC;
using SqlSugar;
using CoreCms.Net.Loging;

namespace CoreCms.Net.Core.Config
{
    public static class SqlSugarSetup
    {
        public static void AddSqlSugarSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //注入ORM
            SugarIocServices.AddSqlSugar(new IocConfig()
            {
                //数据库连接
                ConnectionString = AppSettingsConstVars.DbSqlConnection,
                //判断数据库类型
                DbType = AppSettingsConstVars.DbDbType == IocDbType.MySql.ToString() ? IocDbType.MySql : IocDbType.SqlServer,
                //是否开启自动关闭数据库连接-//不舍城true要手动关闭
                IsAutoCloseConnection = true,
            });
            //设置参数
            services.ConfigurationSugar(db =>
            {
                //InitKeyType.Attribute 表示采用基于属性的方式来指定主键。这意味着 SqlSugar 将会通过属性的标记来确定哪些属性应该被视为表的主键。
                db.CurrentConnectionConfig.InitKeyType = InitKeyType.Attribute;
                db.Aop.OnError = (exp) =>
                {
                    NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.Other, "SqlSugar", "执行SQL错误时间事件", exp);
                };
            });
        }
    }
}