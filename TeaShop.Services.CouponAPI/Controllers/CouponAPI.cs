using AutoMapper;
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
        private readonly IMapper _mapper;
        public CouponAPI(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _responceDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> couponslst = _dbContext.Coupons.ToList();
                _responceDto.Result = _mapper.Map<IEnumerable<CouponDto>>(couponslst);
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
                _responceDto.Result = _mapper.Map<CouponDto>(CounonLst);
                //return Ok(CounonLst);

            }
            catch (Exception ex)
            {

                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }

            return _responceDto;

        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public object GetByCode(string code)
        {
            try
            {
                Coupon cou = _dbContext.Coupons.FirstOrDefault(x => x.CouponCode.ToLower() == code.ToLower());
                if (cou == null)
                {
                    _responceDto.IsSUccess = false;
                    _responceDto.Message = "Invalid Coupon Code";
                    return _responceDto;
                }
                _responceDto.Result = _mapper.Map<CouponDto>(cou);


            }
            catch (Exception ex)
            {

                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }

            return _responceDto;
        }

        [HttpPost]

        public object post([FromBody] CouponDto couponin)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponin);
                _dbContext.Coupons.Add(obj);
                _dbContext.SaveChanges();
                _responceDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {

                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }
            return _responceDto;
        }



        [HttpPut]

        public object put([FromBody] CouponDto couponin)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponin);
                _dbContext.Coupons.Update(obj);
                _dbContext.SaveChanges();
                _responceDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {

                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }
            return _responceDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public object Delete(int id)
        {
            try
            {
                Coupon obj = _dbContext.Coupons.First(x => x.CouponId == id);
                _dbContext.Coupons.Remove(obj);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }
            return _responceDto;
        }

        //_________________________________________________

        [HttpPost("ADD1")]

        public object Add1([FromBody] CouponDto couponin)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponin);
                _dbContext.Coupons.Add(obj);
                _dbContext.SaveChanges();
                _responceDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {

                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }
            return _responceDto;
        }



        [HttpPost("Add2")]

        public object something([FromBody] CouponDto couponin)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponin);
                _dbContext.Coupons.Add(obj);
                _dbContext.SaveChanges();
                _responceDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {

                _responceDto.IsSUccess = false;
                _responceDto.Message = ex.Message;
            }
            return _responceDto;
        }



    }

}
