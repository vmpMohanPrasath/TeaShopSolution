using TeaShop.Web.Models;
using TeaShop.Web.Models.Dto;
using TeaShop.Web.Service.IService;
using TeaShop.Web.Utility;

namespace TeaShop.Web.Service
{
    public class CouponService : ICouponService
    {
        //private readonly ICouponService _couponService;
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                APIType = StaticDetails.ApiType.Post,
                Data = couponDto,
                URL = StaticDetails.CouponAPIBase + "/api/coupon/"

            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int CouponId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                APIType = StaticDetails.ApiType.Delete,
                URL = StaticDetails.CouponAPIBase + "/api/coupon/" + CouponId

            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                APIType = StaticDetails.ApiType.Put,
                Data = couponDto,
                URL = StaticDetails.CouponAPIBase + "/api/coupon/"

            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                APIType = StaticDetails.ApiType.Get,
                URL = StaticDetails.CouponAPIBase + "/api/coupon",
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string CouponCode)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                APIType = StaticDetails.ApiType.Get,
                URL = StaticDetails.CouponAPIBase + "/api/coupon/GetByCode/" + CouponCode

            });
        }

        public async Task<ResponseDto?> GetCouponBuIdAsync(int CouponId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                APIType = StaticDetails.ApiType.Get,
                URL = StaticDetails.CouponAPIBase + "/api/coupon/" + CouponId

            });
        }

        
    }
}
