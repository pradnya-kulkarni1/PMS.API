using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.API.Data;
using PMS.API.Models;

namespace PMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PMSDbContext _pmsDbContext;
        public ProductsController(PMSDbContext pmsDbContext)
        {
            this._pmsDbContext = pmsDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _pmsDbContext.Products.ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            product.Id = Guid.NewGuid();

            await _pmsDbContext.Products.AddAsync(product);
            await _pmsDbContext.SaveChangesAsync();

            return Ok(product);
        }
    }
}
