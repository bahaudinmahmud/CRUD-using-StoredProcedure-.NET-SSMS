using System.ComponentModel.DataAnnotations;

namespace TrollMarket.Presentation.Web.APIModels
{
    public class ShipperDto
    {
        public string ShipperName { get; set; }
        public decimal Price { get; set; }
    }
}
