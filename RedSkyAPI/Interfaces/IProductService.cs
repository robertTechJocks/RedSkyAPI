using System;
using System.Threading.Tasks;
using RedSkyAPI.Models;

namespace RedSkyAPI.Interfaces
{
    public interface IProductService
    {
        public Task<Product> FetchProduct(int id);
        public void UpdateProduct(Product product);
    }
}
