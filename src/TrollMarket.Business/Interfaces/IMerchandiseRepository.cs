using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Interfaces
{
    public interface IMerchandiseRepository
    {
        public void Insert(Product product);
        public List<Product> GetSellerMerchandises(int id);
        public List<Product> GetAllShops();
        public Product GetProductById(int id);
        public void Update(Product product);
        public int GetProductCountInOrders(int productId);
        public void Delete(Product product);

    }
}