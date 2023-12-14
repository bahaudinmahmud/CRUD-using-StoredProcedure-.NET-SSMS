using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrollMarket.Presentation.Web.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string RetypePassword { get; set; }
        public string Role { get; set; }

    }
}
