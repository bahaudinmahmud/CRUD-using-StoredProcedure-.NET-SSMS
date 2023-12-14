using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Interfaces
{
    public interface ISellerRepository
    {
        public Seller GetProfilebyUsername(string username);
        public int GetSellerIdByUsername(string username, string role);
        public Seller GetById(int sellerId);
        public void Update(Seller seller);
    }
}
