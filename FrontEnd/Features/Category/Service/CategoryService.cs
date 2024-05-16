using FrontEnd.Features.Category.Interfaces;
using FrontEnd.Features.Category.Models;
using FrontEnd.Shared.Service.ErrorService;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FrontEnd.Features.Category.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IErrorService _errorService;
        private string errorMessageSample = "[Category]    ";
        private readonly string _apiString;
        private readonly CategoryResponseHelper _responseHelper;
        public CategoryService(HttpClient httpClient, string apiString, IErrorService errorService)
        {
            _errorService = errorService;
            _apiString = apiString;
            _responseHelper = new CategoryResponseHelper(httpClient);
        }



        public async Task<List<GetCountGoodsResponse>> GetAllTopicCategory()
        {
            Uri connectionString = new Uri(_apiString + "getAllTopicCategory");

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = connectionString,
            };
            List<GetCountGoodsResponse> data = new List<GetCountGoodsResponse>();
            try
            {
                data = await _responseHelper.SendAndAcceptListResponse(request);
            }
            catch (Exception ex)
            {
                _errorService.HandleError(errorMessageSample + ex.Message);
            }
            return data;
        }

        public async Task<GetCountGoodsResponse> GetCategoryById(int id)
        {
            Uri connectionString = new Uri(_apiString + id);


            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = connectionString,
            };

            GetCountGoodsResponse data = new GetCountGoodsResponse();
            try
            {
                data = await _responseHelper.SendAndAcceptResponse(request);
            }
            catch (Exception ex)
            {
                _errorService.HandleError(errorMessageSample + ex.Message);
            }
            return data;
        }

        public async Task<GetCountGoodsResponse> UpdateCategory(CategoryUpdateModel categoryUpdate)
        {
            Uri connectionString = new Uri(_apiString + categoryUpdate.CategoryId+"/update");
            var content = new StringContent(JsonConvert.SerializeObject(categoryUpdate.NewCategory), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Patch,
                RequestUri = connectionString,
                Content = content
            };

            GetCountGoodsResponse data = new GetCountGoodsResponse();
            try
            {
                data = await _responseHelper.SendAndAcceptResponse(request);
            }
            catch (Exception ex)
            {
                _errorService.HandleError(errorMessageSample + ex.Message);
            }
            return data;
        }

        public async Task<GetCountGoodsResponse> AddCategory(CategoryRequestModel categoryRequest)
        {
            Uri connectionString = new Uri(_apiString+"add");


            var content = new StringContent(JsonConvert.SerializeObject(categoryRequest), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                RequestUri = connectionString,
                Method = HttpMethod.Post,
                Content = content,
            };

            GetCountGoodsResponse data = new GetCountGoodsResponse();
            try
            {
                data = await _responseHelper.SendAndAcceptResponse(request);
            }
            catch (Exception ex)
            {
                _errorService.HandleError(errorMessageSample + ex.Message);
            }
            return data;
        }
    }
}
