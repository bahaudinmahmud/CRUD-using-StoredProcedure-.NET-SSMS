using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrollMarket.Presentation.Web.Models
{
    public class ShopIndexViewModel
    {
        public int BuyerId{ get; set; }
        public int ProductId{ get; set; }
        public string ProductName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Description { get; set; }
        public List<SelectListItem> Shipments { get; set; }
        public List<ShopViewModel> Shops { get; set;}
        public PaginationInfoViewModel PaginationInfo { get; set; }

    }
}
