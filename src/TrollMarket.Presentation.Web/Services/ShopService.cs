using Microsoft.AspNetCore.Mvc.Rendering;
using TrollMarket.Business.Interfaces;
using TrollMarket.Presentation.Web.Models;

namespace TrollMarket.Presentation.Web.Services
{
    public class ShopService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly IBuyerRepository _buyerRepository;
        public ShopService(IMerchandiseRepository merchandiseRepository, IBuyerRepository buyerRepository, IShipmentRepository shipmentRepository)
        {
            _merchandiseRepository = merchandiseRepository;
            _buyerRepository = buyerRepository;
            _shipmentRepository = shipmentRepository;
        }
        public ShopIndexViewModel GetAllShops()
        {
             var result = _merchandiseRepository.GetAllShops();
            List<ShopViewModel> shops = new List<ShopViewModel>();
            shops = result.Select(s => new ShopViewModel
            {
                Id = s.Id,
                Price = s.Price,
                ProductName = s.ProductName
            }).ToList();
            return new ShopIndexViewModel
            {
                Shops = shops,
                Shipments = GetShipments()
            };
        }
        public List<SelectListItem> GetShipments()
        {
            var shipments = _shipmentRepository.GetAllActiveShippers().
                Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text =s.ShipperName
                }).ToList();
            return shipments;   
        }
        public int GetBuyerId(int accountId)
        {
            return _buyerRepository.GetBuyerIdbyAccountId(accountId);
        }
    }
}
