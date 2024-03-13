using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.Repository.UnitOfWork;
using SqlSugar;
using System.Linq.Expressions;

namespace CoreCms.Net.Repository
{
    #region 仓储通用接口类=======================

    /// <summary>
    ///     仓储通用接口类
    /// </summary>
    /// <typeparam name="T">泛型实体类</typeparam>
    public interface IBaseRepository<T> where T : class, new()
    {
        /// <summary>
        ///     根据条件查询分页数据
        /// </summary>
        /// <param name="predicate">判断集合</param>
        /// <param name="orderByType">排序方式</param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <param name="orderByExpression"></param>
        /// <param name="blUseNoLock">是否使用WITH(NOLOCK)</param>
        /// <returns></returns>
        Task<IPageList<T>> QueryPageAsync(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1,
            int pageSize = 20, bool blUseNoLock = false);
    }

    #endregion 仓储通用接口类=======================

    #region 仓储通用实现类=======================

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly SqlSugarScope _dbBase;

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            _dbBase = unitOfWork.GetDbClient();
        }

        private ISqlSugarClient DbBaseClient => _dbBase;

        public async Task<IPageList<T>> QueryPageAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1, int pageSize = 20, bool blUseNoLock = false)
        {
            RefAsync<int> totalConunt = 0;
            List<T> page = await DbBaseClient
                .Queryable<T>()
                .WhereIF(predicate != null, predicate)
                .OrderByIF(orderByExpression != null, orderByExpression, orderByType)
                .WithNoLockOrNot(blUseNoLock)
                .ToPageListAsync(pageIndex, pageSize, totalConunt);

            IPageList<T> list = new PageList<T>(page, pageIndex, pageSize, totalConunt);
            return list;
        }
    }

    #endregion 仓储通用实现类=======================
}