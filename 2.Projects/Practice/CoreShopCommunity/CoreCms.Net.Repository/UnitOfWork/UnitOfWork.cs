using SqlSugar;
using SqlSugar.IOC;

namespace CoreCms.Net.Repository.UnitOfWork
{
    #region 接口============

    public interface IUnitOfWork
    {
        SqlSugarScope GetDbClient();
    }

    #endregion 接口============

    #region 实现

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlSugarClient _sqlSugarClient;

        public UnitOfWork()
        {
            _sqlSugarClient = DbScoped.SugarScope;
        }

        public SqlSugarScope GetDbClient()
        {
            //必须要用as，后边会用到切换数据库操作
            return _sqlSugarClient as SqlSugarScope;
        }
    }

    #endregion 实现
}