using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RedSkyAPI.Models;
using RedSkyAPI.Interfaces;

namespace RedSkyAPI.Services
{
    public class RedSkyService : IRedSkyService
    {
        public HttpClient Client { get; }

        public RedSkyService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://redsky.target.com/");

            Client = client;
        }
        public async Task<RedSkyResponse> FetchProductAsync(int productId)
        {
            RedSkyResponse resp = new RedSkyResponse();
            try
            {
                resp = await Client.GetFromJsonAsync<RedSkyResponse>(
          $"v3/pdp/tcin/{productId}?excludes=taxonomy,price,promotion,bulk_ship,rating_and_review_reviews,rating_and_review_statistics,question_answer_statistics&key=candidate");
            }
            catch(HttpRequestException ex)
            {
                //catching exception here, exception handled downstream in ProductService
            }
            return resp;
            
        }
    }
}
