using CodeChallenge.Core.Models;

namespace CodeChallenge.Core.Implementations
{
    public interface ICouponValidator
    {
        bool IsValid(Coupon coupon);
    }
}