using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;
using TrollMarket.Presentation.Web.Helpers;
using TrollMarket.Presentation.Web.Models;

namespace TrollMarket.Presentation.Web.Services
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBuyerRepository _buyerRepository;
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly ISellerRepository _sellerRepository;
        private readonly IOrderRepository _orderRepository;

        public CartService(
            ICartRepository cartRepository, 
            IBuyerRepository buyerRepository, 
            IMerchandiseRepository merchandiseRepository,
            ISellerRepository sellerRepository,
            IOrderRepository orderRepository
            )
            
        {
            _cartRepository = cartRepository;
            _buyerRepository = buyerRepository;
            _merchandiseRepository = merchandiseRepository;
            _sellerRepository = sellerRepository;
            _orderRepository = orderRepository;
        }
        public int GetBuyerId(int accountId)
        {
            return _buyerRepository.GetBuyerIdbyAccountId(accountId);
        }
        public CartIndexViewModel GetBuyersCarts(int buyerId)
        {
            var result = _cartRepository.GetCartByBuyerId(buyerId);
            List<CartViewModel> carts = new List<CartViewModel>();
            carts = result.Select(c => new CartViewModel
            {
                BuyerId = buyerId,
                ProductId = c.ProductId,
                ProductName = c.Product.ProductName,
                ShipperName = c.Shipper.ShipperName,
                SellerName = c.Product.Seller.Name,
                Quantity = c.Quantity,
                TotalPrice = (c.Quantity*c.Product.Price)+(c.Shipper.Price)
            }).ToList();
            return new CartIndexViewModel
            {
                Carts = carts
            };
        }
        public void HasEnoughMoney(int buyerId)
        {
            var buyer = _buyerRepository.GetBuyerbyId(buyerId);
            var cartItems = _cartRepository.GetCartByBuyerId(buyerId);
            decimal totalPurchaseAmount = 0;
            foreach (var cartItem in cartItems)
            {
                var product = _merchandiseRepository.GetProductById(cartItem.ProductId);

                totalPurchaseAmount += (cartItem.Quantity * product.Price) + cartItem.Shipper.Price;
            }

            if(buyer.Balance >= totalPurchaseAmount)
            {
                buyer.Balance -= totalPurchaseAmount;
                PurchaseAll(buyerId);
            }
            else
            {
                throw new EnoughBalanceException("Your balance isnt enough to purchase all of this items");

            }

        }
        public void PurchaseAll(int buyerId)
        {
            var cartItems = _cartRepository.GetCartByBuyerId(buyerId);
            decimal totalPurchaseAmount = 0;
            foreach (var cartItem in cartItems)
            {
                var product = _merchandiseRepository.GetProductById(cartItem.ProductId);
                var seller = _sellerRepository.GetById(product.SellerId); 
                if (seller != null) {
                    seller.Balance += cartItem.Quantity * product.Price;
                    _sellerRepository.Update(seller);
                }
                if (product != null)
                {
                    var order = new Order
                    {
                        BuyerId = buyerId,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        OrderDate = DateTime.Now,
                        ShipperId = cartItem.ShipperId
                    };
                    _orderRepository.Add(order);

                }
            }

            _cartRepository.Delete(buyerId);
            _cartRepository.PurchaseAll();

        }
        public void Delete(int buyerId,int productId)
        {
            var cart = _cartRepository.GetCartByCK(buyerId, productId);
            _cartRepository.DeleteByCK(cart);
        }
    }
}
