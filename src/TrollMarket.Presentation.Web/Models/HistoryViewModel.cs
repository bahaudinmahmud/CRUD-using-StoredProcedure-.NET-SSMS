namespace TrollMarket.Presentation.Web.Models
{
    public class HistoryViewModel
    {
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public string Shipment { get; set; }
        public string SellerName { get; set; }
        public string BuyerName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
