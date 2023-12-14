using System.ComponentModel.DataAnnotations;

namespace TrollMarket.Presentation.Web.APIModels
{
    public class ShipperUpsertDto
    {
        public int Id { get; set; }
        [Required]
        public string ShipperName { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
      
    }
}
