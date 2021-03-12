using CodeChallenge.Core.Implementations;
using CodeChallenge.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace CodeChallenge.ConsoleApp
{
    public class CouponTask
    {
        private readonly ICouponGenerator _couponGenerator;
        private readonly ICouponValidator _couponValidator;

        public CouponTask(ICouponGenerator couponGenerator, ICouponValidator couponValidator)
        {
            _couponGenerator = couponGenerator;
            _couponValidator = couponValidator;
        }

        public long Attempts { get; private set; }

        public Task<Coupon> DoWork()
        {
            Coupon validCoupon = null;


            while (validCoupon == null)
            {
                var coupon = _couponGenerator.GenerateCoupon();
                if (_couponValidator.IsValid(coupon))
                {
                    validCoupon = coupon;
                }
                Attempts++;
            }

            return Task.FromResult(validCoupon);
        }

    }
}
