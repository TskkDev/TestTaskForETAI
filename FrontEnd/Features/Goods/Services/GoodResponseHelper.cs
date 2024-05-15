using Newtonsoft.Json;
using SharedModels.Models.RespondModels.Response;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FrontEnd.Features.Category.Service
{
    public class GoodResponseHelper
    {
        private readonly HttpClient _httpClient;
        public GoodResponseHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetCategoryNameResponse>> SendAndAcceptListResponse(HttpRequestMessage request)
        {
            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<GetCategoryNameResponse>>(json);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new NullReferenceException(response.Content.ToString());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new InvalidDataException(response.Content.ToString());
                }
                throw new Exception("unknown error on server side");
            }
        }

        public async Task<GetCategoryNameResponse> SendAndAcceptResponse(HttpRequestMessage request)
        {
            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetCategoryNameResponse>(json);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new NullReferenceException(response.Content.ToString());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new InvalidDataException(response.Content.ToString());
                }
                throw new Exception("unknown error on server side");
            }
        }

    }
}
