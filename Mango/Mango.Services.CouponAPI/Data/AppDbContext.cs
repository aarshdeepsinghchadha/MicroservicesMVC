using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Coupon>().HasData(
            //new Coupon
            //{
            //    CouponId = 1,
            //    CouponCode = "WELCOME10",
            //    DiscountAmount = 10.0,
            //    MinAmount = 50
            //},
            //new Coupon
            //{
            //    CouponId = 2,
            //    CouponCode = "SUMMER20",
            //    DiscountAmount = 20.0,
            //    MinAmount = 100
            //},
            //new Coupon
            //{
            //    CouponId = 3,
            //    CouponCode = "FALL15",
            //    DiscountAmount = 15.0,
            //    MinAmount = 75
            //},
            //new Coupon
            //{
            //    CouponId = 4,
            //    CouponCode = "WINTER25",
            //    DiscountAmount = 25.0,
            //    MinAmount = 150
            //},
            //new Coupon
            //{
            //    CouponId = 5,
            //    CouponCode = "SPRING30",
            //    DiscountAmount = 30.0,
            //    MinAmount = 200
            //}
        );

        }
    }
}
