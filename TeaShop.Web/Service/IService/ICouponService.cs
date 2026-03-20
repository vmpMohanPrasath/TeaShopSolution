using TeaShop.Web.Models;
using TeaShop.Web.Models.Dto;

namespace TeaShop.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?>  GetCouponAsync(string CouponCode);

        Task<ResponseDto?> GetCouponBuIdAsync(int CouponId);
        Task<ResponseDto?> GetAllCouponAsync();

        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponAsync(int CouponId);


    }
}
