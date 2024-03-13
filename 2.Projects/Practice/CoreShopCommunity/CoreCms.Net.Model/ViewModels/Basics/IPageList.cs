/***********************************************************************
 *            Project: CoreCms
 *        ProjectName: 核心内容管理系统
 *                Web: https://www.corecms.net
 *             Author: 大灰灰
 *              Email: jianweie@163.com
 *         CreateTime: 2021/1/31 21:45:10
 *        Description: 暂无
 ***********************************************************************/

using System.Collections.Generic;

namespace CoreCms.Net.Model.ViewModels.Basics
{
    public interface IPageList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }

    /// <summary>
    ///     分页组件实体类
    /// </summary>
    /// <typeparam name="T">泛型实体</typeparam>

    public class PageList<T> : List<T>, IPageList<T>
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="totalCount">总记录数</param>
        public PageList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;
            if (TotalCount % pageSize > 0) TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }

        /// <summary>
        ///     分页索引
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        ///     分页大小
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        ///     总记录数
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        ///     总页数
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        ///     是否有上一页
        /// </summary>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        ///     是否有下一页
        /// </summary>
        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}