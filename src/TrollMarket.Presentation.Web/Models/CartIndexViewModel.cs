namespace TrollMarket.Presentation.Web.Models
{
    public class CartIndexViewModel
    {
        public int BuyerId { get; set; }        
        public List<CartViewModel> Carts { get; set; }
    }
}
