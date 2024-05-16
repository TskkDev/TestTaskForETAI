using FrontEnd.Features.Goods.Interfaces;
using FrontEnd.Features.Goods.Models;
using FrontEnd.Features.Goods.Service;
using FrontEnd.Shared.Service.ErrorService;
using Newtonsoft.Json;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Response;
using System.Text;

namespace FrontEnd.Features.Goods.Services
{
    public class GoodService: IGoodService
    {
        private readonly IErrorService _errorService;
        private readonly string _apiString;
        private GoodResponseHelper _responseHelper;
        private string errorMessageSample = "[Goods]    ";
        public GoodService(HttpClient httpClient, string apiString, IErrorService errorService)
        {
            _errorService = errorService;
            _apiString = apiString;
            _responseHelper = new GoodResponseHelper(httpClient);
        }

        public async Task<List<GetCategoryNameResponse>> GetGoodsFromCategory(int id)
        {
            Uri connectionString = new Uri(_apiString + $"caregory/{id}/goods");

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = connectionString,
            };

            List<GetCategoryNameResponse> data = new List<GetCategoryNameResponse>();
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

        public async Task<List<GetCategoryNameResponse>> GetGoodsFromCategoryWithSort(
            int id, string fieldName, bool ascending)
        {
            Uri connectionString = new Uri(_apiString + $"caregory/{id}/sortGoods" +
                $"?fieldName={fieldName}&ascending={ascending}");

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = connectionString,
            };

            List<GetCategoryNameResponse> data = new List<GetCategoryNameResponse>();
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

        public async Task<GetCategoryNameResponse> AddGood(GoodRequestModel goodRequest)
        {
            Uri connectionString = new Uri(_apiString + "good/add");

            var content = new StringContent(JsonConvert.SerializeObject(goodRequest), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                RequestUri = connectionString,
                Method = HttpMethod.Post,
                Content = content,
            };

            GetCategoryNameResponse data = new GetCategoryNameResponse();
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

        public async Task<GetCategoryNameResponse> UpdateGood(UpdateGoodModel updateGood)
        {
            Uri connectionString = new Uri(_apiString + $"goods/{updateGood.GoodId}/update");

            var content = new StringContent(JsonConvert.SerializeObject(updateGood.NewGood), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                RequestUri = connectionString,
                Method = HttpMethod.Patch,
                Content = content,
            };

            GetCategoryNameResponse data = new GetCategoryNameResponse();
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


        public async Task DeleteGood(int goodId)
        {
            Uri connectionString = new Uri(_apiString + $"goods/{goodId}/delete");

            var request = new HttpRequestMessage()
            {
                RequestUri = connectionString,
                Method = HttpMethod.Delete
            };
            try
            {
                var data = await _responseHelper.SendAndAcceptResponse(request);

            }
            catch(Exception ex)
            {
                _errorService.HandleError(errorMessageSample + ex.Message);
            }
        }
    }
}
