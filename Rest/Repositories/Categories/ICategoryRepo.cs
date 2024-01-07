using EntityLayer.Models;
using Rest.Models;

namespace Rest.Repositories.Categories
{
    public interface ICategoryRepo
    {
        Task<List<CategoryDetail>> GetCategories();
    }
}
