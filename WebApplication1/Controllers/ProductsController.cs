using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProjectPatisserie.DatatAccess;
using ProjectPatisserie.Dtos.Products;
using ProjectPatisserie.Entities;

namespace ProjectPatisserie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProductDto create)
        {
            Product product = new()
            {
                CategoryId = create.CategoryId,
                BarcodeNumber = create.BarcodeNumber,
                Name = create.Name,
                Price = create.Price,
            };
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            CreateProductResponseDto createProductResponseDto = result.Entity.Adapt<CreateProductResponseDto>();
            return Ok(createProductResponseDto);
        }

    }
}
