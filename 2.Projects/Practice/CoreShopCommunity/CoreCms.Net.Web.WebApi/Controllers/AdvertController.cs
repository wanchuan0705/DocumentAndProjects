using CoreCms.Net.Model.FromBody;
using CoreCms.Net.Model.ViewModels.UI;
using CoreCms.Net.Services.Advert;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace CoreCms.Net.Web.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly ICoreCmsAdvertisementServices _advertisementServices;
        /// <summary>
        /// 构造函数
        /// </summary>

        public AdvertController(ICoreCmsAdvertisementServices advertisementServices)
        {
            _advertisementServices = advertisementServices;
        }

        #region 获取广告列表========================================

        [HttpPost]
        public async Task<WebApiCallBack> GetAdvertList([FromBody] FMPageByIntId entity)
        {
            var jm = new WebApiCallBack();
            var list = await _advertisementServices.QueryPageAsync(p => p.code == entity.where, p => p.createTime, OrderByType.Desc, entity.page, entity.limit);
            jm.status = true;
            jm.data = list;
            return jm;
        }

        #endregion 获取广告列表========================================
    }
}