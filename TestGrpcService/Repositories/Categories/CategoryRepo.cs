using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using TestGrpcService.Models.Categories;

namespace TestGrpcService.Repositories.Categories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly GrpcTestContext _context;

        public CategoryRepo(GrpcTestContext context)
        {
            _context = context;
        }

        public async Task Add(CategoryAddModel model)
        {
            var category = new Category()
            {
                CategoryName = model.CategoryName,
                Description = model.Description,
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
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
