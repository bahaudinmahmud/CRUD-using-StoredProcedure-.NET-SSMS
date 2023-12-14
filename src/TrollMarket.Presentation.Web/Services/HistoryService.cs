using Microsoft.AspNetCore.Mvc.Rendering;
using TrollMarket.Business.Interfaces;
using TrollMarket.Presentation.Web.Models;

namespace TrollMarket.Presentation.Web.Services
{
    public class HistoryService
    {
        private readonly IOrderRepository _orderRepository;
        public HistoryService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<SelectListItem> GetBuyers()
        {
            var buyers = _orderRepository.GetBuyers()
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString(),

                }).ToList();
            return buyers;    
        }       
        
        public List<SelectListItem> GetSellers()
        {
            var sellers = _orderRepository.GetSellers()
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString(),

                }).ToList();
            return sellers;    
        }

        public HistoryIndexViewModel GetHistoryIndexViewModel(int? buyerId, int? sellerId)
        {
            var result = _orderRepository.GetAllOrders(buyerId,sellerId);
            List<HistoryViewModel> histories = new List<HistoryViewModel>();
            histories = result.Select(h => new HistoryViewModel
            {
                OrderDate = h.OrderDate,
                ProductName = h.Product.ProductName,
                Quantity = h.Quantity,
                Shipment = h.Shipper.ShipperName,
                TotalPrice = (h.Quantity * h.Product.Price) + (h.Shipper.Price),
                BuyerName = h.Buyer.Name,
                SellerName = h.Product.Seller.Name
            }).ToList();

            return new HistoryIndexViewModel
            {
                Histories = histories,
                Buyers = GetBuyers(),
                Sellers = GetSellers(),
            };
        }



    }
}
