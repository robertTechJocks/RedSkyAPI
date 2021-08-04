using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using RedSkyAPI.Models;
using RedSkyAPI.Interfaces;

namespace RedSkyAPI.Services
{
    /* Pricing Service
     * This handles interaction with the MongoDB to fetch/update prices
     */
    public class PricingService : IPricingService
    {
        private readonly IMongoCollection<PricingModel> _prices;

        public PricingService(IPricingDatabaseSettings pricingDatabaseSettings)
        {
            MongoClient client = new MongoClient(pricingDatabaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(pricingDatabaseSettings.DatabaseName);

            _prices = database.GetCollection<PricingModel>(pricingDatabaseSettings.CollectionName);
        }

        public PricingModel Get(int id) =>
            _prices.Find<PricingModel>(p => p.ProductId == id).FirstOrDefault();

        public void Update(PricingModel newPrice)
        {
            UpdateDefinition<PricingModel> updateDef = Builders<PricingModel>.Update.Set(p => p.Price, newPrice.Price);
            _prices.UpdateOne(p => p.ProductId == newPrice.ProductId, updateDef);
        }
    }
}
