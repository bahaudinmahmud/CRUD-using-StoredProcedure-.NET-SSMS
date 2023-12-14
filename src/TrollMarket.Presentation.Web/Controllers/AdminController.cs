using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TrollMarket.Presentation.Web.Models;
using TrollMarket.Presentation.Web.Services;

namespace TrollMarket.Presentation.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;
        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet("registerAdmin")]
        public IActionResult RegisterAdmin()
        {

            return View("index");
        }
        [HttpPost("registerAdmin")]
        public IActionResult RegisterAdmin(AdminViewModel vm)
        {
            try
            {
                _adminService.Register(vm);
                return RedirectToAction("registerAdmin");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("register", vm);
            }
        }
    }
}
