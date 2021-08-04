using System;
using System.Net.Http;
using System.Threading.Tasks;
using RedSkyAPI.Interfaces;

namespace RedSkyAPI.Models
{
    public class CurrentPrice
    {
        public double Value { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CurrentPrice CurrentPrice { get; set; }
    }

}
