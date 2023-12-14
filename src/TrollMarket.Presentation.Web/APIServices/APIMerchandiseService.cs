using TrollMarket.Business.Interfaces;
using TrollMarket.Presentation.Web.APIModels;

namespace TrollMarket.Presentation.Web.APIServices
{
    public class APIMerchandiseService
    {
        private readonly IMerchandiseRepository _merchandiseRepository;
        public APIMerchandiseService(IMerchandiseRepository merchandiseRepository)
        {
            _merchandiseRepository = merchandiseRepository;
        }

        public MerchandiseDto GetDetail(int Id)
        {
            var merchandise = _merchandiseRepository.GetProductById(Id);
            return new MerchandiseDto
            {
                Name = merchandise.ProductName,
                Category = merchandise.Category,
                Description = merchandise.Description,
                Price = merchandise.Price,
                Seller = merchandise.Seller.Name
            };
        }
    }
}
