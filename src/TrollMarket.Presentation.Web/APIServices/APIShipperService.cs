using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;
using TrollMarket.Presentation.Web.APIModels;

namespace TrollMarket.Presentation.Web.APIServices
{
    public class APIShipperService
    {
        private readonly IShipmentRepository _shipmentRepository;
        public APIShipperService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }
        public void Insert(ShipperUpsertDto vm)
        {
            Shipper shipper = new Shipper
            {
                ShipperName = vm.ShipperName,
                Price = vm.Price,
            };
            _shipmentRepository.Insert(shipper);
        }
        public ShipperDto GetShipperById(int  id)
        {
            var shipper = _shipmentRepository.GetById(id);
            return new ShipperDto
            {
                ShipperName = shipper.ShipperName,
                Price = shipper.Price,
            };

        }
        public void Update(ShipperUpsertDto vm)
        {
            var shipper = _shipmentRepository.GetById(vm.Id);
            shipper.ShipperName = vm.ShipperName;
            shipper.Price = vm.Price;

            _shipmentRepository.Update(shipper);

        }
        public int CountShipperOnOrder(int shipperId)
        {
            return _shipmentRepository.CountShipperOnOrder(shipperId);
        }

    }
}
