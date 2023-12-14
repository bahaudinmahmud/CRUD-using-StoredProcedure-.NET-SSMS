namespace TrollMarket.Presentation.Web.Models
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SellerName { get; set; }
        public string Category { get; set; }
       
    }
}
