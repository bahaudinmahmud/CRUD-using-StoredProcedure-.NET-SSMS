namespace TrollMarket.Presentation.Web.APIModels
{
    public class CartDto
    {
        public int BuyerId { get; set; }
        public int ShipperId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
