using Microsoft.EntityFrameworkCore;
using TeaShop.Services.CouponAPI.Models;

namespace TeaShop.Services.CouponAPI.Data
{
    public class AppDbContext: DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
