namespace TrollMarket.Presentation.Web.Models
{
    public class TransactionViewModel
    {
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public string Shipment { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
