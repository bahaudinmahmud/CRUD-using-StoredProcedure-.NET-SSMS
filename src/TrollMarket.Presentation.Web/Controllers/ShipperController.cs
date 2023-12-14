using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TrollMarket.Presentation.Web.Services;

namespace TrollMarket.Presentation.Web.Controllers
{
    [Authorize(Roles = "admin")]

    public class ShipperController : Controller
    {
        private readonly ShipperService _shippingService;
        public ShipperController (ShipperService shipperService)
        {
            _shippingService = shipperService;  
        }
        public IActionResult Index()
        {
            var vm = _shippingService.GetAllShippers();
            return View(vm);
        }
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int Id) 
        {
          var dependent = _shippingService.CountShipperOnOrder(Id);
            if(dependent>0)
            {
                return View("DeleteFailed");
            }
            _shippingService.Delete(Id);
            return RedirectToAction("Index");
        }
        [HttpGet("StopService")] 
        public IActionResult StopService(int Id) 
        { 
           _shippingService.StopService(Id);
            return RedirectToAction("Index");
        }
    }
}
