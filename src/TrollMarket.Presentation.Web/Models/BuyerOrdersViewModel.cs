namespace TrollMarket.Presentation.Web.Models
{
    public class BuyerOrdersViewModel
    {
        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public string ShipperName { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
