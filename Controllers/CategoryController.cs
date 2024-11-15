using Application;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _categoryService.GetCategoryByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {

            
            return await _categoryService.GetAllCategoriesAsync();
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(Category category)
        {
            await _categoryService.AddCategoryAsync(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
