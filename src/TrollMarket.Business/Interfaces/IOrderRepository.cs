using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Interfaces
{
    public interface IOrderRepository
    {
        public void Add(Order order);
        public List<Order> GetAllBuyerOrders(string username, string role);
        public List<Order> GetAllSellerOrders(string username, string role);
        public List<Order> GetAllOrders(int? buyerId,int? sellerId);
        public List<Seller> GetSellers();
        public List<Buyer> GetBuyers();

    }
}
