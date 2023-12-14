namespace TrollMarket.Presentation.Web.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public decimal Balance { get; set; }
        public string Role { get; set; } = null!;
    }
}
