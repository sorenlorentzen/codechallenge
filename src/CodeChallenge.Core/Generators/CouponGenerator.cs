using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Generators
{
    public interface ICouponGenerator
    {
        Coupon GenerateCoupon(int luckyNumber);
    }


    public class CouponGenerator : ICouponGenerator
    {
        public Coupon GenerateCoupon(int luckyNumber)
        {
            throw new NotImplementedException();
        }
    }
}
