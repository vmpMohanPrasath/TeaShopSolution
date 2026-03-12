using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Services.CouponAPI.Data;
using TeaShop.Services.CouponAPI.Models;
using TeaShop.Services.CouponAPI.Models.Dto;

namespace TeaShop.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPI : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly ResponseDto _responceDto;

        public CouponAPI(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _responceDto = new ResponseDto();
        }

        [HttpGet]
        public object Get()
        {
            try
            {
               IEnumerable<Coupon> couponslst =_dbContext.Coupons.ToList();
                _responceDto.Result = couponslst;
                //return Ok(couponslst);

            }
            catch (Exception ex)
            {

                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }

            return _responceDto; 
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {

            Coupon CounonLst = _dbContext.Coupons.First(x => x.CouponId == id);
            _responceDto.Result = CounonLst;
                //return Ok(CounonLst);

            }
            catch (Exception ex)
            {

                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }

            return _responceDto ;

        }

    }
}
