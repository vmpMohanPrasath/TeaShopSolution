using TeaShop.Web.Models;
using TeaShop.Web.Models.Dto;
namespace TeaShop.Web.Service.IService
{
    public interface IBaseService
    {
            Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
