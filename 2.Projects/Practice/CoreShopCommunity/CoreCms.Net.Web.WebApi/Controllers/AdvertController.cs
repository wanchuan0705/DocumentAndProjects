using CoreCms.Net.Model.FromBody;
using CoreCms.Net.Model.ViewModels.UI;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Net.Web.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        #region 获取广告列表========================================

        [HttpPost]
        public async Task<WebApiCallBack> GetAdvertList([FromBody] FMPageByIntId entity)
        {
            var jm = new WebApiCallBack();

            return jm;
        }

        #endregion 获取广告列表========================================
    }
}