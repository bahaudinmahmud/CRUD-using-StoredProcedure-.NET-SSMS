using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly TrollMarketContext _context;
        public CartRepository(TrollMarketContext context)
        {
            _context = context;
        }
        public void Insert(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }       
        public void Update(Cart cart)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
        }
        public Cart GetCartByCK(int buyerId, int productId) {
              return _context.Carts.FirstOrDefault(c=> c.BuyerId == buyerId && c.ProductId == productId);
        }
        public List<Cart> GetCartByBuyerId(int buyerId)
        {
            return _context.Carts
                .Include(c => c.Product.Seller)
                .Include(c=> c.Product)
                .Include(c=> c.Shipper)
                .Where(c=>c.BuyerId==buyerId).ToList();
        }
        public void Delete(int buyerId) 
        {
            var cartItemsToRemove = _context.Carts.Where(c => c.BuyerId == buyerId);
            _context.RemoveRange(cartItemsToRemove);
        }
        public void PurchaseAll()
        {
            _context.SaveChanges();
        }
        public void DeleteByCK(Cart cart)
        {
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

    }
}
