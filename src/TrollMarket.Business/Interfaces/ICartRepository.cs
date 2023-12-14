using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Interfaces
{
    public interface ICartRepository
    {
        public void Insert(Cart cart);
        public void Update(Cart cart);
        public Cart GetCartByCK(int buyerId, int productId);
        public List<Cart> GetCartByBuyerId(int buyerId);
        public void Delete(int buyerId);
        public void PurchaseAll();
        public void DeleteByCK(Cart cart);
    }
}
