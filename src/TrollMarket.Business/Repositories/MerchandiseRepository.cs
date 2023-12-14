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
    public class MerchandiseRepository: IMerchandiseRepository
    {
        private readonly TrollMarketContext _dbContext;

        public MerchandiseRepository(TrollMarketContext dbContext)
        {
            _dbContext = dbContext;
        }
       //public int Get
        public void Insert( Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public List<Product> GetSellerMerchandises(int id) {
        
            var  sellerMechandises = _dbContext.Products
                .Include(p => p.Seller)
                .Where(p => p.SellerId == id).ToList();
            return sellerMechandises;
        }
        public List<Product> GetAllShops() {
            var  sellerMechandises = _dbContext.Products
                .Where(p => p.Discontinue == false)
                .ToList();
            return sellerMechandises;
        }
        public Product GetProductById(int id)
        {
            return _dbContext.Products
                .Include(p => p.Seller)
                .FirstOrDefault(product => product.Id == id);
        }
        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }
        public int GetProductCountInOrders(int productId)
        {
            return _dbContext.Orders.Count(o => o.ProductId == productId);
        }
        public void Delete(Product product)
        {
            _dbContext.Products.Remove(product); 
            _dbContext.SaveChanges();
        }





    }
}
