using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrollMarket.Presentation.Web.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string Role { get; set; }
    }
}
