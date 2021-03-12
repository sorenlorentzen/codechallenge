using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Implementations
{
    public class LuckyNumberCouponLoopsValidator : ICouponValidator
    {
        private readonly int _luckyNumber;

        public LuckyNumberCouponLoopsValidator(int luckyNumber)
        {
            _luckyNumber = luckyNumber;
        }

        public bool IsValid(Coupon coupon)
        {
            foreach (var row in coupon.Rows)
            {
                var rowIsValid = false;
                foreach (var number in row.Numbers)
                {
                    if (number == _luckyNumber)
                    {
                        rowIsValid = true;
                    }
                }
                if (rowIsValid == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
