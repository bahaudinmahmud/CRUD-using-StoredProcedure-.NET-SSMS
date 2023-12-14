using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using TrollMarket.Presentation.Web.Models;
using TrollMarket.Presentation.Web.Services;

namespace TrollMarket.Presentation.Web.Controllers;
[Authorize(Roles = "seller")]

[Route("[Controller]")]
public class MerchandiseController : Controller
{
    private readonly MerchandiseService _merchandiseService;
    public  MerchandiseController(MerchandiseService merchandiseService)
    {
        _merchandiseService = merchandiseService;
    }
    [HttpGet("insert")]
    public IActionResult Insert()
    {
        var role = User.FindFirst(ClaimTypes.Role).Value;
        var username = User.FindFirst("username").Value;
        var sellerId = _merchandiseService.GetSellerID(username,role);
        var vm = new MerchandiseUpsertViewModel { SellerId = sellerId };
        return View("upsert",vm);
    }
    [HttpPost("insert")]
    public IActionResult Insert(MerchandiseUpsertViewModel vm)
    {
        _merchandiseService.Insert(vm);
        return RedirectToAction("index","merchandise");
    }
    [HttpGet("update/{id}")]
    public IActionResult Update(int id)
    {
        var dependent = _merchandiseService.GetProductCountOnOrder(id);
        if (dependent > 0)
        {
            return View("DeleteFailed");
        }
        var vm = _merchandiseService.GetMerchandiseById(id);
        return View("upsert", vm);
    }    
    [HttpPost("update/{id}")]
    public IActionResult Update(MerchandiseUpsertViewModel merchandise)
    {
        _merchandiseService.Update(merchandise);
        return RedirectToAction("index", "merchandise");
    }
    [HttpGet("index")]
    public IActionResult Index()
    {
        var role = User.FindFirst(ClaimTypes.Role).Value;
        var username = User.FindFirst("username").Value;
        var sellerId = _merchandiseService.GetSellerID(username,role);
        var vm = _merchandiseService.GetSellersMerchandises(sellerId);
        return View(vm);
    }
    [HttpGet("delete/{id}")]
    public IActionResult Delete(int id) 
    { 
        var dependent =_merchandiseService.GetProductCountOnOrder(id);
        if(dependent > 0)
        {
            return View("DeleteFailed");
        }
        _merchandiseService.Delete(id);
        return RedirectToAction("index");
    }
    [HttpGet("discontinue/{id}")]
    public IActionResult Discontinue(int id) 
    { 
      _merchandiseService.Discontinue(id);
        return RedirectToAction("index");
    }
}
