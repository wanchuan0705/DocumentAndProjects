using CoreCms.Net.Model.Entities.Advert;
using CoreCms.Net.Repository.Advert;
using CoreCms.Net.Repository.UnitOfWork;

namespace CoreCms.Net.Services.Advert
{
    /// <summary>
    /// 广告表 服务工厂接口
    /// </summary>
    public interface ICoreCmsAdvertisementServices : IBaseServices<CoreCmsAdvertisement>
    {
    }

    /// <summary>
    ///     广告表 接口实现
    /// </summary>
    public class CoreCmsAdvertisementServices : BaseServices<CoreCmsAdvertisement>, ICoreCmsAdvertisementServices
    {
        private readonly ICoreCmsAdvertisementRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsAdvertisementServices(IUnitOfWork unitOfWork, ICoreCmsAdvertisementRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}