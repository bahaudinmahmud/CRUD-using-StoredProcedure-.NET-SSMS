using System.Security.Claims;
using TrollMarket.Business.Interfaces;
using TrollMarket.DataAccess.Models;
using TrollMarket.Presentation.Web.Models;

namespace TrollMarket.Presentation.Web.Services
{
    public class MerchandiseService
    {
        private readonly IMerchandiseRepository _merchandiseRepository;
        private readonly ISellerRepository _sellerRepository;
        public MerchandiseService(IMerchandiseRepository merchandiseRepository, ISellerRepository sellerRepository)
        {
            _merchandiseRepository = merchandiseRepository;
            _sellerRepository = sellerRepository;
        }

        public int GetSellerID(string username,string role)
        {

            return _sellerRepository.GetSellerIdByUsername(username,role);
        }

        public void Insert(MerchandiseUpsertViewModel vm)
        {
            Product newProduct = new Product 
            {ProductName = vm.ProductName,
            Category = vm.Category,
            SellerId = vm.SellerId,
            Price = vm.Price,
            Description = vm.Description,
            };

            _merchandiseRepository.Insert(newProduct);
        }
        public MerchandiseIndexViewModel GetSellersMerchandises(int sellerId)
        {
            var result = _merchandiseRepository.GetSellerMerchandises(sellerId);
            List<MerchandiseViewModel> merchandises = new List<MerchandiseViewModel>();
            merchandises = result.Select(m => new MerchandiseViewModel
            {
                Id = m.Id,
                ProductName = m.ProductName,
                Category = m.Category,
                Discontinue =m.Discontinue,
                Price = m.Price,
                SellerName = m.Seller.Name,
                Description = m.Description
            }).ToList();
            return new MerchandiseIndexViewModel { Merchandises = merchandises};
        }

        public MerchandiseUpsertViewModel GetMerchandiseById(int id)
        {
            var merchandise = _merchandiseRepository.GetProductById(id);
            return new MerchandiseUpsertViewModel
            {
                Category = merchandise.Category,
                Price = merchandise.Price,
                ProductName = merchandise.ProductName,
                Description = merchandise.Description,

            };
        }

        public void Update(MerchandiseUpsertViewModel vm)
        {
            var product = _merchandiseRepository.GetProductById(vm.Id);
            product.ProductName = vm.ProductName;
            product.Description = vm.Description;
            product.Price = vm.Price;
            product.Category = vm.Category;

            _merchandiseRepository.Update(product);

        }
        public int GetProductCountOnOrder(int Id)
        {
           return _merchandiseRepository.GetProductCountInOrders(Id);
        }
        public void Delete(int Id)
        {
            var product = _merchandiseRepository.GetProductById(Id);
            _merchandiseRepository.Delete(product);
        }
        public void Discontinue(int id)
        {
            var product = _merchandiseRepository.GetProductById(id);
            product.Discontinue = true;
            _merchandiseRepository.Update(product);

        }


    }
}
