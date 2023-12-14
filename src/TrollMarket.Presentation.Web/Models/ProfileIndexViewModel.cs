namespace TrollMarket.Presentation.Web.Models
{
    public class ProfileIndexViewModel
    {
        public ProfileViewModel Profile { get; set; }
        public int AccountId { get; set; }
        public List<TransactionViewModel> Transactions { get; set; } 
    }
}
