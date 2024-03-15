using CoreCms.Net.Model.Entities.Advert;
using CoreCms.Net.Repository.UnitOfWork;

namespace CoreCms.Net.Repository.Advert
{
    /// <summary>
    /// 广告表 工厂接口
    /// </summary>
    public interface ICoreCmsAdvertisementRepository : IBaseRepository<CoreCmsAdvertisement>
    {
    }

    /// <summary>
    ///     广告表 接口实现
    /// </summary>
    public class CoreCmsAdvertisementRepository : BaseRepository<CoreCmsAdvertisement>, ICoreCmsAdvertisementRepository
    {
        public CoreCmsAdvertisementRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}