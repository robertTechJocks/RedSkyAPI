using System;
namespace RedSkyAPI.Interfaces
{
    public interface IPricingDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
