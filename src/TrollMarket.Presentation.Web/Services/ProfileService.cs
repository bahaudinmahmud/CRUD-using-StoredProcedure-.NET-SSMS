using TrollMarket.Business.Interfaces;
using TrollMarket.Presentation.Web.Models;

namespace TrollMarket.Presentation.Web.Services
{
    public class ProfileService
    {
        private readonly IBuyerRepository _buyerRepository;
        private readonly ISellerRepository _sellerRepository;
        private readonly IOrderRepository _orderRepository;

        public ProfileService (IBuyerRepository buyerRepository, ISellerRepository sellerRepository, IOrderRepository orderRepository)
        {
            _buyerRepository = buyerRepository;
            _sellerRepository = sellerRepository;
            _orderRepository = orderRepository;
        }
        
        public ProfileViewModel GetProfile(string username,string role)
        {
            if (role.Equals("buyer"))
            {
                return GetBuyerProfile(username);
            }
            return GetSellerProfile(username);
        }

        public ProfileViewModel GetBuyerProfile(string username)
        {
            var profile = _buyerRepository.GetProfilebyUsername(username);
            return new ProfileViewModel { 
                Name = profile.Name,
                Address = profile.Address,
                Balance = profile.Balance,
                Role = profile.Account.Role
            };
        }        
        
        public ProfileViewModel GetSellerProfile(string username)
        {
            var profile = _sellerRepository.GetProfilebyUsername(username);
            return new ProfileViewModel { 
                Name = profile.Name,
                Address = profile.Address,
                Balance = profile.Balance,
                Role = profile.Account.Role
            };
        }

        public List<TransactionViewModel> GetOrders(string username,string role) 
        {
            if (role.Equals("buyer"))
            {
                var resultBuyer= _orderRepository.GetAllBuyerOrders(username,role);
                List<TransactionViewModel> orders = new List<TransactionViewModel>();   
                orders = resultBuyer.Select( o => new TransactionViewModel 
                {
                    OrderDate = o.OrderDate,
                    ProductName = o.Product.ProductName,
                    Quantity = o.Quantity,
                    Shipment = o.Shipper.ShipperName,
                    TotalPrice = (o.Quantity * o.Product.Price) + (o.Shipper.Price)
                }).ToList();
                return orders;
            }
            else
            {
                var result = _orderRepository.GetAllSellerOrders(username, role);
                List<TransactionViewModel> sellerOrders = new List<TransactionViewModel>();
                sellerOrders = result.Select(o => new TransactionViewModel
                {
                    OrderDate = o.OrderDate,
                    ProductName = o.Product.ProductName,
                    Quantity = o.Quantity,
                    Shipment = o.Shipper.ShipperName,
                    TotalPrice = (o.Quantity * o.Product.Price) + (o.Shipper.Price)
                }).ToList();
                return sellerOrders;
            }

           
        }

        




    }
}
