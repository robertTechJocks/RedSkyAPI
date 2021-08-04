using System;
using System.Threading.Tasks;
using RedSkyAPI.Interfaces;
using RedSkyAPI.Models;
namespace RedSkyAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IRedSkyService _redSkyService;
        private readonly IPricingService _pricingService;

        public ProductService(IRedSkyService redSkyService, IPricingService pricingService)
        {
            _redSkyService = redSkyService;
            _pricingService = pricingService;
        }

        public async Task<Product> FetchProduct(int id)
        {
            RedSkyResponse redSkyResponse = await _redSkyService.FetchProductAsync(id);

            if(redSkyResponse.product == null)
            {
                return new Product();
            }
            PricingModel pricingModel = _pricingService.Get(id);

            if(pricingModel == null)
            {
                return new Product
                {
                    Id = id,
                    Name = redSkyResponse.product.item.product_description.title,
                    CurrentPrice = null
                };
            }
            CurrentPrice currentPrice = new CurrentPrice
            {
                Value = (double)pricingModel.Price,
                CurrencyCode = pricingModel.Currency
            };
            Product product = new Product {
                Id = id,
                Name = redSkyResponse.product.item.product_description.title,
                CurrentPrice = currentPrice
            };

            return product;
        }

        public void UpdateProduct(Product product)
        {
            PricingModel pricingModel = new PricingModel
            {
                ProductId = product.Id,
                Price = (decimal)product.CurrentPrice.Value,
                Currency = product.CurrentPrice.CurrencyCode
            };

            _pricingService.Update(pricingModel);

        }
    }
}
