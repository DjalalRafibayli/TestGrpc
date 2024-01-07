using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Rest.Models;

namespace Rest.Repositories.Categories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly GrpcTestContext _context;

        public CategoryRepo(GrpcTestContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDetail>> GetCategories()
        {
            var categories = await _context.Categories.Select(x => new CategoryDetail
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToListAsync();
            return categories;
        }
    }
}
