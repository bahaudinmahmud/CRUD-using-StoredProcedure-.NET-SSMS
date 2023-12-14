using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TrollMarketContext _dbContext;

        public AccountRepository (TrollMarketContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Account CheckIfUserNameExist(string userName, string role)
        {
            var user = _dbContext.Accounts.FirstOrDefault(a => a.Username.Equals(userName) && a.Role.Equals(role))
            ?? throw new KeyNotFoundException("Username not found!");
            return user;
        }
        public void Register(Account account, string name, string address)
        {

            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();

                var lastAccountId = _dbContext.Accounts
                                  .OrderByDescending(a => a.Id)
                                  .Select(a => a.Id)
                                  .FirstOrDefault();

                if (account.Role.Equals("buyer"))
                {
                    Buyer buyer = new Buyer
                    {
                        Name = name,
                        Address = address,
                        AccountId = lastAccountId
                    };

                    _dbContext.Buyers.Add(buyer);
                    _dbContext.SaveChanges();
                }
                else
                {
                    Seller seler = new Seller
                    {
                        Name = name,
                        Address = address,
                        AccountId = lastAccountId
                    };
                    _dbContext.Sellers.Add(seler);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                }
                
            }

            catch
            {
                transaction.Rollback(); 
                throw new Exception("Sorry, the server are some server problems, try again later");
            }
        }
        public bool CheckUserNameAvailable(string userName,string role)
        {
            var user = _dbContext.Accounts.FirstOrDefault(a => a.Username.Equals(userName) && a.Role.Equals(role));
            return user != null;
        }
        public void  RegisterAdmin(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

    }
}
