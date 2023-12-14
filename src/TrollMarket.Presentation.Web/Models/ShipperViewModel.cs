namespace TrollMarket.Presentation.Web.Models
{
    public class ShipperViewModel
    {
        public string ShipperName { get; set; }

        public decimal Price { get; set; }

        public bool Service { get; set; }
        public int Id { get; set; }
        public int ShipperOnLoan { get; set; }
    }
}
