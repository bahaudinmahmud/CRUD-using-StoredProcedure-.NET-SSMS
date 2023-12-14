using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly TrollMarketContext _dbContext;

        public OrderRepository(TrollMarketContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Order order)
        {
            _dbContext.Orders.Add(order);
        }
        public List<Order> GetAllBuyerOrders(string username,string role) 
        {

            return _dbContext.Orders
                .Include(o => o.Product)
                .Include(o => o.Shipper)
                .Where(order => order.Buyer.Account.Username
                .Equals(username)&& order.Buyer.Account.Role.Equals(role)).ToList();
        }
        public List<Order> GetAllSellerOrders(string username, string role) 
        {
            return _dbContext.Orders
                .Include(o => o.Product)
                .Include(o => o.Shipper)
                .Where(order => order.Product.Seller.Account.Username
                .Equals(username) && order.Product.Seller.Account.Role.Equals(role)).ToList();
        } 
        public List<Order> GetAllOrders(int? buyerId, int? sellerId) 
        {
            return _dbContext.Orders
                .Include(o => o.Product)
                .Include(o => o.Shipper)
                .Include(o => o.Buyer)
                .Include(o => o.Product.Seller)
                .Where(o => (o.BuyerId ==  buyerId || buyerId == null)&&
                (sellerId == null || o.Product.SellerId == sellerId))
                .ToList();
        }
        public List<Buyer> GetBuyers()
        {
            return _dbContext.Buyers.ToList();
        }        
        public List<Seller> GetSellers()
        {
            return _dbContext.Sellers.ToList();
        }

    }
}
