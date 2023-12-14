namespace TrollMarket.Presentation.Web.Models
{
    public class CartViewModel
    {
        public string ProductName { get; set; }
        public string ShipperName { get; set; }
        public string SellerName { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
    }
}
