using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Implementations
{

    public class LuckyNumberCouponLinqValidator : ICouponValidator
    {
        private readonly int _luckyNumber;

        public LuckyNumberCouponLinqValidator(int luckyNumber)
        {
            _luckyNumber = luckyNumber;
        }

        public bool IsValid(Coupon coupon)
        {
            return coupon.Rows.All(row => row.Numbers.Any(num => num == _luckyNumber));
        }
    }
}
