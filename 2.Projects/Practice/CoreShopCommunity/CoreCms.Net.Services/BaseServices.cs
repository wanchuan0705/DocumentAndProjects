using CoreCms.Net.Model.ViewModels.Basics;
using SqlSugar;
using System.Linq.Expressions;

namespace CoreCms.Net.Services
{
    #region 服务仓储通用接口类======================

    public interface IBaseServices<T> where T : class
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
        Task<IPageList<T>> QueryPageAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByExpression, OrderByType orderByType, int pageIndex = -1, int pageSize = 20, bool blUseNoLock = false);
    }

    #endregion 服务仓储通用接口类======================

    #region 服务仓储通用实现类======================

    public class BaseServices<T> : IBaseServices<T> where T : class, new()
    {
        public IBaseRepository<T> BaseDal;

        public Task<IPageList<T>> QueryPageAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByExpression, OrderByType orderByType, int pageIndex = -1, int pageSize = 20, bool blUseNoLock = false)
        {
            throw new NotImplementedException();
        }
    }

    #endregion 服务仓储通用实现类======================
}