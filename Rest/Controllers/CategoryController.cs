using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Models;
using Rest.Repositories.Categories;

namespace Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;


        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        [HttpGet]
        public async Task<List<CategoryDetail>> GetAll()
        {
            return await _categoryRepo.GetCategories();
        }
    }
}
