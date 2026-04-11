using TeaShop.Web.Models;
namespace TeaShop.Web.Service.IService
{
    public interface IBaseService
    {
            Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
