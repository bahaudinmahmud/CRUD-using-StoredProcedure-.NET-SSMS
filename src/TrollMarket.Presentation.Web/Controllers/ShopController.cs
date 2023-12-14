using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TrollMarket.Presentation.Web.Services;

namespace TrollMarket.Presentation.Web.Controllers
{
    [Authorize(Roles = "buyer")]

    public class ShopController : Controller
    {
        private readonly ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }
        public IActionResult Index()
        {
            var accountId = User.FindFirst("id").Value;
            var vm = _shopService.GetAllShops();
            vm.BuyerId = _shopService.GetBuyerId(int.Parse(accountId));
            return View(vm);
        }
    }
}
