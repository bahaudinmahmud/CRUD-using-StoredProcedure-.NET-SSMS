using System.ComponentModel.DataAnnotations;

namespace TrollMarket.Presentation.Web.Models
{
    public class MerchandiseUpsertViewModel
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = null!;
        [Required]
        public string Category { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int SellerId { get; set; }

    }
}
