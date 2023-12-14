using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TrollMarket.Presentation.Web.Models;
using TrollMarket.Presentation.Web.Services;

namespace TrollMarket.Presentation.Web.Controllers;
[Route("[Controller]")]
public class AuthController : Controller
{
    private readonly AuthService _authService;
    private readonly ILogger<AuthController> _logger;
    public AuthController(ILogger<AuthController> logger, AuthService authService)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View("Login");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        try 
        {
            var authTicket = _authService.Login(vm);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                authTicket.Principal, authTicket.Properties);

            return RedirectToAction("Index", "Home");
        }

        catch (Exception e)
        {
            ViewBag.ErrorMessage = e.Message;
            return View("login", vm);
        }

    }
        [HttpGet("register")]
    public IActionResult register(string role)
    {
        var vm = new RegisterViewModel { Role = role };
        return View("Register",vm);
    }
    [HttpPost("register")]
    public IActionResult register(RegisterViewModel vm)
    {
        try
        {
            _authService.Register(vm);
            return RedirectToAction("Login");
        }
        catch (Exception e)
        {
            ViewBag.ErrorMessage = e.Message;
            return View("register", vm);
        }
    }
    [HttpPost("logout")]
    public async Task<IActionResult> logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");

    }
    [HttpGet("AccessDenied")]
    public IActionResult AccessDenied()
    {
        return View("AccessDenied");
    }


}
