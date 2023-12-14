using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Interfaces
{
    public interface IBuyerRepository
    {
        public Buyer GetProfilebyUsername(string username);
        public int GetBuyerIdbyAccountId(int accountId);
        public void TopUp(Buyer buyer);
        public Buyer GetBuyerbyAccountId(int accountId);
        public Buyer GetBuyerbyId(int Id);
        public List<Buyer> GetBuyers();   

    }
}
