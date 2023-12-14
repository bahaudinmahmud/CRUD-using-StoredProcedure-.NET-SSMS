using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;

namespace TrollMarket.Business.Interfaces
{
    public interface IAccountRepository
    {
        public bool CheckUserNameAvailable(string userName, string role);
        public Account CheckIfUserNameExist(string userName, string role);
        public void Register(Account account, string name, string address);
        public void RegisterAdmin(Account account);


    }
}
