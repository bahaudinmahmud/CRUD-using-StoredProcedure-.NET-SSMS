using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;
using TrollMarket.Presentation.Web.APIModels;

namespace TrollMarket.Presentation.Web.APIServices
{
    public class APICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBuyerRepository  _buyerRepository;
        public APICartService(ICartRepository cartRepository, IBuyerRepository buyerRepository)
        {
            _cartRepository = cartRepository;
            _buyerRepository = buyerRepository; 
        }
        public void Insert(CartDto dto)
        {

            var existCart = _cartRepository.GetCartByCK(dto.BuyerId, dto.ProductId);

            if (existCart!=null)
            {
                existCart.ShipperId = dto.ShipperId;
                existCart.Quantity = dto.Quantity;
                _cartRepository.Update(existCart);
            }
            else
            {
                Cart cart = new Cart
                {
                    Quantity = dto.Quantity,
                    ProductId = dto.ProductId,
                    ShipperId = dto.ShipperId,
                    BuyerId = dto.BuyerId,
                };
            _cartRepository.Insert(cart);
            }

        }


    }
}
