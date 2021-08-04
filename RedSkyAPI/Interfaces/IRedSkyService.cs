using System;
using System.Threading.Tasks;
using RedSkyAPI.Models;

namespace RedSkyAPI.Interfaces
{
    public interface IRedSkyService
    {
        public Task<RedSkyResponse> FetchProductAsync(int productId);
    }
}
