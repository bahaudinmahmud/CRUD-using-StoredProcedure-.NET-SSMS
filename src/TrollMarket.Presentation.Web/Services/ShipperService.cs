using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;
using TrollMarket.Presentation.Web.Models;

namespace TrollMarket.Presentation.Web.Services
{
    public class ShipperService
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipperService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }   
        public ShipperIndexViewModel GetAllShippers()
        {
           var result = _shipmentRepository.GetAllShippers();
           List<ShipperViewModel> shippers = new List<ShipperViewModel>();
            shippers = result.Select(shipper => new ShipperViewModel
            {
                Price = shipper.Price,
                ShipperName = shipper.ShipperName,
                Service = shipper.Service,
                Id = shipper.Id,
                ShipperOnLoan = CountShipperOnOrder(shipper.Id)

            }).ToList();
            return new ShipperIndexViewModel
            {
                Shippers = shippers
            };
        }
        public int CountShipperOnOrder(int shipperId)
        {
            return _shipmentRepository.CountShipperOnOrder(shipperId);
        }
        public void Delete(int shipperId)
        {
            var shipper = _shipmentRepository.GetById(shipperId);
            _shipmentRepository.Delete(shipper);
        }
        public void StopService(int shipperId)
        {
            var shipper = _shipmentRepository.GetById(shipperId);
            shipper.Service = false;
            _shipmentRepository.Update(shipper);
        }
    }
}
