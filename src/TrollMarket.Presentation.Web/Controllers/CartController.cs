using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TrollMarket.Presentation.Web.Helpers;
using TrollMarket.Presentation.Web.Services;

namespace TrollMarket.Presentation.Web.Controllers
{
    [Authorize(Roles = "buyer")]

    public class CartController : Controller
    {
        private readonly CartService _cartService;
        public CartController (CartService cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            var accountId = User.FindFirst("id").Value;
            var buyerId = _cartService.GetBuyerId(int.Parse(accountId));
            var vm = _cartService.GetBuyersCarts(buyerId);
            vm.BuyerId = buyerId;
            return View(vm);
        }
        [HttpGet("purchaseAll")]
        public IActionResult PurchaseAll(int buyerId)
        {
            try { 
            _cartService.HasEnoughMoney(buyerId);             
                return RedirectToAction("index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return RedirectToAction("index");
            }          
        }
        [HttpGet("delete")]
        public IActionResult Delete(int buyerId,int productId)
        {
            _cartService.Delete(buyerId, productId);
            return RedirectToAction("index");
        }
    }                                                                           
}
