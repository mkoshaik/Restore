using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(StoreContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //this ToList() method is going to query our database and return all the products.
          return  await context.Products.ToListAsync();
        }

        [HttpGet("{id}")] //api/products/2

        public async Task <ActionResult<Product>> GetProduct(int id)
        {
            var product = await context.Products.FindAsync(id);
            
            if(product == null) return  NotFound();

            return  product;
        }
    }
}
