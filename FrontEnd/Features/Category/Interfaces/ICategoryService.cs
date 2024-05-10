using FrontEnd.Features.Category.Models;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<GetCountGoodsResponse>> GetAllTopicCategory();
        public Task<GetCountGoodsResponse> GetCategoryById(int id);
        public Task<GetCountGoodsResponse> UpdateCategory(CategoryUpdateModel categoryUpdate);
        public Task<GetCountGoodsResponse> AddCategory(CategoryRequestModel categoryRequest);
    }
}
