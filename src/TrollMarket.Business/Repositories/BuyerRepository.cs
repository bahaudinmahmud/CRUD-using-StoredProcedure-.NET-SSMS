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
    public class BuyerRepository: IBuyerRepository
    {
        private readonly TrollMarketContext _dbContext;

        public BuyerRepository(TrollMarketContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Buyer GetProfilebyUsername(string username) { 
         
            var buyer = _dbContext.Buyers.Include(buyer => buyer.Account).
                FirstOrDefault(buyer => buyer.Account.Username.Equals(username));
            return buyer;
        }
        public int GetBuyerIdbyAccountId(int accountId)
        {
            var buyer = _dbContext.Buyers.FirstOrDefault(b => b.AccountId == accountId);
            return buyer.Id;
        }        
        public Buyer GetBuyerbyAccountId(int accountId)
        {
            var buyer = _dbContext.Buyers.FirstOrDefault(b => b.AccountId == accountId);
            return buyer;
        }
        public Buyer GetBuyerbyId(int Id)
        {
            var buyer = _dbContext.Buyers.FirstOrDefault(b => b.Id == Id);
            return buyer;
        }
        public void TopUp(Buyer buyer)
        {
            _dbContext.Buyers.Update(buyer);
            _dbContext.SaveChanges();
        }
        public List<Buyer> GetBuyers()
        {
            return _dbContext.Buyers.ToList();
        }

    }
}
