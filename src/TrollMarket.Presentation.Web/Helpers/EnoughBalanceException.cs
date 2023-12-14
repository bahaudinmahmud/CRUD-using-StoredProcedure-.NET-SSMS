namespace TrollMarket.Presentation.Web.Helpers
{
    public class EnoughBalanceException : Exception
    {
        public EnoughBalanceException(string? message) : base(message){ }
    }
}
