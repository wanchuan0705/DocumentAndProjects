namespace CoreCms.Net.Configuration
{
    public class AppSettingsConstVars
    {
        #region 数据库================================================================================

        public static readonly string DbSqlConnection = AppSettingsHelper.GetContent("ConnectionStrings", "SqlConnection");

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public static readonly string DbDbType = AppSettingsHelper.GetContent("ConnectionStrings", "DbType");

        #endregion 数据库================================================================================
    }
}