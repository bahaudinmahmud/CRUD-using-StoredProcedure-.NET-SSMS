using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using TrollMarket.Presentation.Web.Models;
using TrollMarket.Presentation.Web.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TrollMarket.Presentation.Web.Controllers
{
    [Authorize(Roles = "buyer,seller")]
    public class ProfileController : Controller
    {

        private readonly ProfileService _profileService;
        public ProfileController(ProfileService profileService) { 
        _profileService = profileService;
        }
        [HttpGet("profile")]
        public IActionResult Index()
        {
            var accountId = int.Parse(User.FindFirst("id").Value);           
            var username = User.FindFirst("username").Value;
            var role = User.FindFirst(ClaimTypes.Role).Value;
            var profile = _profileService.GetProfile(username, role);
            var orders = _profileService.GetOrders(username,role);
            var vm = new ProfileIndexViewModel 
            { 
                Profile = profile,
                AccountId = accountId,
                Transactions = orders
            };   
            return View(vm);
        }

    }
}
