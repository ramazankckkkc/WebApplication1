using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPatisserie.DatatAccess;
using ProjectPatisserie.Dtos.Categories;
using ProjectPatisserie.Entities;

namespace ProjectPatisserie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string categoryId)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            GetByIdCategoryDto getByIdCategoryDto = category.Adapt<GetByIdCategoryDto>();
            return Ok(getByIdCategoryDto);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCategoryRequestDto createCategory)
        {
            Category category = createCategory.Adapt<Category>();
            category.CreatedDate = DateTime.Now.AddHours(3);
            var result = await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            CreateCategoryResponseDto createCategoryResponseDto = result.Entity.Adapt<CreateCategoryResponseDto>();
            return Ok(createCategoryResponseDto);
        }
    }
}
