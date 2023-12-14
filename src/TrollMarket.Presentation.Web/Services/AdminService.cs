using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;
using TrollMarket.Presentation.Web.Models;

namespace TrollMarket.Presentation.Web.Services
{
    public class AdminService
    {
        private readonly IAccountRepository _accountRepository;
        public AdminService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }
        public void Register(AdminViewModel vm)
        {
            bool isRegistered = _accountRepository.CheckUserNameAvailable(vm.UserName, vm.Role);
            if (isRegistered)
            {
                throw new Exception("Username already used for this role");
            }
            else if (vm.Password != vm.RetypePassword)
            {
                throw new Exception("Password doesnt match!");
            }

            Account newAccount =
                    new Account
                    {
                        Username = vm.UserName,
                        Password = BCrypt.Net.BCrypt.HashPassword(vm.Password),
                        Role = vm.Role,
                    };
            //Role = vm.Role};
            _accountRepository.RegisterAdmin(newAccount);

        }
    }
}
