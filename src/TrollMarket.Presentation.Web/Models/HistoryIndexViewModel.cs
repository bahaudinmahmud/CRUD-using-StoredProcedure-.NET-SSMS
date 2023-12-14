using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrollMarket.Presentation.Web.Models
{
    public class HistoryIndexViewModel
    {
        public List<HistoryViewModel> Histories { get; set; }
        public List<SelectListItem> Buyers { get; set; }
        public List<SelectListItem> Sellers { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set;}
    }
}
