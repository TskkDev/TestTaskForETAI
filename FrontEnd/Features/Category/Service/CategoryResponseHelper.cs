using Newtonsoft.Json;
using SharedModels.Models.RespondModels.Response;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FrontEnd.Features.Category.Service
{
    public class CategoryResponseHelper
    {
        HttpClient _httpClient;
        public CategoryResponseHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<GetCountGoodsResponse>> SendAndAcceptListResponse(HttpRequestMessage request)
        {
            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<GetCountGoodsResponse>>(json);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new NullReferenceException(response.Content.ToString());
                }
                throw new Exception("unknown error on server side");
            }
        }

        public async Task<GetCountGoodsResponse> SendAndAcceptResponse(HttpRequestMessage request)
        {
            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new NullReferenceException(response.Content.ToString());
                }
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new InvalidDataException(response.Content.ToString());
                }
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetCountGoodsResponse>(json);
                }
                throw new Exception("unknown error on server side");
            }
        }

    }
}
