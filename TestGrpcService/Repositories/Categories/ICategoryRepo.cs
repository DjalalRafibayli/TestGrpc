using TestGrpcService.Models.Categories;

namespace TestGrpcService.Repositories.Categories
{
    public interface ICategoryRepo
    {
        Task<List<CategoryDetail>> GetCategories();
        Task Add(CategoryAddModel model);
    }
}
