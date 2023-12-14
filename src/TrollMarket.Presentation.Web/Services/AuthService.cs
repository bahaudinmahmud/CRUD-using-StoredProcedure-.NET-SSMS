using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;
using TrollMarket.Presentation.Web.Models;
using TrollMarket.Presentation.Web.Helpers;

namespace TrollMarket.Presentation.Web.Services
{
    public class AuthService
    {
        private readonly IAccountRepository _accountRepository;
        public AuthService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void Register(RegisterViewModel vm)
        {
            bool isRegistered = _accountRepository.CheckUserNameAvailable(vm.UserName,vm.Role);
            if (isRegistered)
            {
                throw new Exception("Username already used for this role");
            }
            else if (vm.Password != vm.RetypePassword)
            {
                throw new Exception("Password doesnt match!");
            }
            var name = vm.UserName;
            var address = vm.Address;
            Account newAccount =
                    new Account
                    {
                        Username = vm.UserName,
                        Password = BCrypt.Net.BCrypt.HashPassword(vm.Password),
                        Role = vm.Role,
                    };
            //Role = vm.Role};
            _accountRepository.Register(newAccount,name,address);

        }
        private AuthenticationTicket GetAuthenticationTicket(ClaimsPrincipal principal)
        {


            AuthenticationProperties authenticationProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.Now,
                ExpiresUtc = DateTime.Now.AddMinutes(30),
                AllowRefresh = false
            };

            AuthenticationTicket authenticationTicket = new AuthenticationTicket(principal, authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme);

            return authenticationTicket;
        }
        private ClaimsPrincipal GetPrincipal(Account account)
        {
            var claims = new List<Claim>
            {
                new Claim ("username", account.Username),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("id",account.Id.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(identity);
        }
        public AuthenticationTicket Login(LoginViewModel vm)
        {
            var existUser = _accountRepository.CheckIfUserNameExist(vm.UserName,vm.Role);
            bool isCorrect = BCrypt.Net.BCrypt.Verify(vm.Password, existUser.Password);
            if (!isCorrect)
            {
                throw new  PasswordException("username atau pasworrd anda salah");
            }

            ClaimsPrincipal principal = GetPrincipal(existUser);
            AuthenticationTicket authenticationTicket = GetAuthenticationTicket(principal);
            return authenticationTicket;
        }

    }
}
