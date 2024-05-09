using FrontEnd.Features.Category.Models;
using Newtonsoft.Json;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;
using System.Net.Http;

namespace FrontEnd.Features.Category.Service
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiString;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiString = "https://localhost:7273/category/";
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


            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new NullReferenceException();
                }
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<GetCountGoodsResponse>>(json);
                }

                return await Task.FromResult(data);
            }
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


            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new NullReferenceException("Doesn't have this category");
                }
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<GetCountGoodsResponse>(json);
                }

                return await Task.FromResult(data);
            }
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

            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new NullReferenceException(response.Content.ToString());
                }
                if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new InvalidDataException(response.Content.ToString());
                }
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<GetCountGoodsResponse>(json);
                }
                return await Task.FromResult(data);
            }
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

            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new NullReferenceException(response.Content.ToString());
                }
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<GetCountGoodsResponse>(json);
                }

                return await Task.FromResult(data);
            }
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
