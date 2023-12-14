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
    public class SellerRepository : ISellerRepository
    {
        private readonly TrollMarketContext _dbContext;

        public SellerRepository(TrollMarketContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Seller GetProfilebyUsername(string username)
        {

            var seller = _dbContext.Sellers.Include(seller => seller.Account).
                FirstOrDefault(seller => seller.Account.Username.Equals(username));
            return seller;
        }
        public int GetSellerIdByUsername(string username,string role)
        {
            var seller = _dbContext.Sellers.
                Include(seller => seller.Account).
                //Where(seller => seller.Account.Role.Equals("seller") && ).
                FirstOrDefault(seller => seller.Account.Username.Equals(username)&& seller.Account.Role.Equals(role));
            int sellerId = seller.Id;
            return sellerId;
        }
        public Seller GetById(int sellerId)
        {
            return _dbContext.Sellers.FirstOrDefault(seller => seller.Id == sellerId);
        }

        public void Update(Seller seller)
        {
            _dbContext.Sellers.Update(seller);
        }

    }
}
