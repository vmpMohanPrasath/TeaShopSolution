
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using TeaShop.Web.Models;
using TeaShop.Web.Models.Dto;
using TeaShop.Web.Service.IService;
using TeaShop.Web.Utility;
using static TeaShop.Web.Utility.StaticDetails;

namespace TeaShop.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        // 1. URl
        // 2. Data
        // 3. API Type (Get, Post, Put, Delete)
        // 4. Access Token

        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            try
            {

            var client = _httpClientFactory.CreateClient("TeaShopAPI");

                HttpRequestMessage message = new HttpRequestMessage();


            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(requestDto.URL);

            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? ApiResponse = null;

            switch (requestDto.APIType)
            {
                case ApiType.Post:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.Put:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.Delete:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            ApiResponse = await client.SendAsync(message);

            switch (ApiResponse.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return new ResponseDto
                    {
                        IsSUccess = false,
                        Message = "Bad Request"
                    };
                case HttpStatusCode.Forbidden:
                    return new ResponseDto
                    {
                        IsSUccess = false,
                        Message = "Forbidden"
                    };
                case HttpStatusCode.NotFound:
                    return new ResponseDto
                    {
                        IsSUccess = false,
                        Message = "Not Found"
                    };
                case HttpStatusCode.Unauthorized:

                    return new ResponseDto
                    {
                        IsSUccess = false,
                        Message = "Unauthorized"
                    };


                case HttpStatusCode.InternalServerError:
                    return new ResponseDto
                    {
                        IsSUccess = false,
                        Message = "Internal Server Error"
                    };

                default:
                    var apiContent = await ApiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
            }


            }
            catch (Exception EX)
            {
                var Dto =  new ResponseDto
                {
                    IsSUccess = false,
                    Message = EX.Message
                };

                return Dto;

            }

        }
    }
}

