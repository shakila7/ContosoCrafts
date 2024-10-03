using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService productService { get; }
        public ProductsController(JsonFileProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = productService.GetProducts();
            return products;
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery]string productId, 
            [FromQuery]int rating)
        {
            productService.AddRating(productId, rating);
            return Ok();
        }
    }
}
