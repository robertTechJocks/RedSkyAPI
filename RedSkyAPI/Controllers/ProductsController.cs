using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedSkyAPI.Interfaces;
using RedSkyAPI.Models;

namespace RedSkyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;


        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            Product product = await _productService.FetchProduct(id);
            if(product.Id == 0)
            {
                return NotFound("Product Not Found");
            }
            if (product.CurrentPrice == null)
            {
                return NotFound("Pricing Not Found");
            }
            return Ok(product);
        }

        [HttpPut]
        public void Put(Product product)
        {
            _productService.UpdateProduct(product);
        }
    }
}
