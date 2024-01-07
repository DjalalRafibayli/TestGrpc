using Grpc.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using TestGrpcService.Models.Categories;
using TestGrpcService.Repositories.Categories;

namespace TestGrpcService.Services
{
    public class CategoryService : CategoryServiceGrpc.CategoryServiceGrpcBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public override async Task<Empty> Add(CategroryAdd request, ServerCallContext context)
        {
            var categoryAdd = new CategoryAddModel()
            {
                Description = request.Description,
                CategoryName = request.CategoryName,
            };
            await _categoryRepo.Add(categoryAdd);
            return new Empty();

        }

        public override async Task<Categories> GetCategories(Empty request, ServerCallContext context)
        {
            context.Status = new Status(StatusCode.NotFound, "No categories found.");

            var categories = await _categoryRepo.GetCategories();
            return new Categories
            {
                Categories_ = { categories }
            };
        }
    }
}
