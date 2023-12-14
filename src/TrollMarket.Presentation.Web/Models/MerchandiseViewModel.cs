namespace TrollMarket.Presentation.Web.Models
{
    public class MerchandiseViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public bool Discontinue { get; set; }
        public string Description { get; set; }
        public string SellerName { get; set; }
        public decimal Price { get; set; }
    }
}
