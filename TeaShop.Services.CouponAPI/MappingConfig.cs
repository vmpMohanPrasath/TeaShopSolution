using Microsoft.EntityFrameworkCore.Metadata;
using AutoMapper;
using TeaShop.Services.CouponAPI.Models;
using TeaShop.Services.CouponAPI.Models.Dto;

namespace TeaShop.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>();
                config.CreateMap<CouponDto, Coupon>();
            });
            return mappingConfig;
        }
    }
}
