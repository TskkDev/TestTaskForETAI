using FrontEnd.Features.Category.Interfaces;
using FrontEnd.Features.Category.Models;
using Newtonsoft.Json;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;
using System.Net.Http;

namespace FrontEnd.Features.Category.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiString;
        private readonly CategoryResponseHelper _responseHelper;
        public CategoryService(HttpClient httpClient, string apiString)
        {
            _httpClient = httpClient;
            _apiString = apiString;
            _responseHelper = new CategoryResponseHelper(httpClient);
        }



        public async Task<List<GetCountGoodsResponse>> GetAllTopicCategory()
        {
            Uri connectionString = new Uri(_apiString + "getAllTopicCategory");
            List<GetCountGoodsResponse> data = new List<GetCountGoodsResponse>();


            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = connectionString,
            };

            data = await _responseHelper.SendAndAcceptListResponse(request);
            return await Task.FromResult(data);
        }

        public async Task<GetCountGoodsResponse> GetCategoryById(int id)
        {
            Uri connectionString = new Uri(_apiString + id);
            GetCountGoodsResponse data = new GetCountGoodsResponse();


            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = connectionString,
            };


            data = await _responseHelper.SendAndAcceptResponse(request);
            return await Task.FromResult(data);
        }

        public async Task<GetCountGoodsResponse> UpdateCategory(CategoryUpdateModel categoryUpdate)
        {
            Uri connectionString = new Uri(_apiString + categoryUpdate.CategoryId+"/update");
            GetCountGoodsResponse data = new GetCountGoodsResponse();


            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Patch,
                RequestUri = connectionString,
                Content = new StringContent(JsonConvert.SerializeObject(categoryUpdate.NewCategory))
            };

            data = await _responseHelper.SendAndAcceptResponse(request);
            return await Task.FromResult(data);
        }

        public async Task<GetCountGoodsResponse> AddCategory(CategoryRequestModel categoryRequest)
        {
            Uri connectionString = new Uri(_apiString+"/add");
            GetCountGoodsResponse data = new GetCountGoodsResponse();


            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Patch,
                RequestUri = connectionString,
                Content = new StringContent(JsonConvert.SerializeObject(categoryRequest))
            };

            data = await _responseHelper.SendAndAcceptResponse(request);
            return await Task.FromResult(data);
        }

        public List<GetCountGoodsResponse> ChangeCategoryInListCategories
            (
            IEnumerable<GetCountGoodsResponse> categoryList, int oldCategoryId,
            GetCountGoodsResponse newCategory)
        {
            var newCategoryList = categoryList.Select(c =>
            {
                if(c.Id == oldCategoryId)
                {
                    if (c.IsVisible)
                    {
                        newCategory.IsVisible = false;
                    }
                    return newCategory;
                }
                else if (c.SubCategories != null && c.SubCategories.Any())
                {
                    var updatedSubCategories = ChangeCategoryInListCategories(c.SubCategories, oldCategoryId, newCategory);
                    c.SubCategories = updatedSubCategories;
                }
                return c;
            }).ToList();

            return newCategoryList;
        }
    }
}
