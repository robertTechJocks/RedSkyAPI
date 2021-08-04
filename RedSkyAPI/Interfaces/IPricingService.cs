using System;
using RedSkyAPI.Models;

namespace RedSkyAPI.Interfaces
{
    public interface IPricingService
    {
        public PricingModel Get(int id);
        public void Update(PricingModel newPrice);
    }
}
