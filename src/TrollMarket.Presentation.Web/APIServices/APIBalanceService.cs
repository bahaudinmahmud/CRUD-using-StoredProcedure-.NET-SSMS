using TrollMarket.Business.Interfaces;
using TrollMarket.Presentation.Web.APIModels;

namespace TrollMarket.Presentation.Web.APIServices
{
    public class APIBalanceService
    {
        private readonly IBuyerRepository _buyerRepository;
        public APIBalanceService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }
        public int GetBuyerId(int accountId)
        {
            return _buyerRepository.GetBuyerIdbyAccountId(accountId);
        }
        public void TopUp(BalanceDto dto)
        {
            var buyer = _buyerRepository.GetBuyerbyAccountId(dto.AccountId);
            buyer.Balance = dto.BalanceNominal + buyer.Balance;
            _buyerRepository.TopUp(buyer);
        }
    }
}
