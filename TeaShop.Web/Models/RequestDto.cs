using Microsoft.AspNetCore.Authentication.BearerToken;
using static TeaShop.Web.Utility.StaticDetails;

namespace TeaShop.Web.Models
{
    public class RequestDto
    {
        public ApiType APIType { get; set; } = ApiType.Get;
        public string URL { get; set; } = "";
        public object Data { get; set; }
        public string AccessToken {  get; set; }
        
    }
}
