using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Implementations
{
    public interface ICouponGenerator
    {
        Coupon GenerateCoupon();
    }


    public class CouponGenerator : ICouponGenerator
    {
        private readonly IRowGenerator _rowGenerator;

        public CouponGenerator(IRowGenerator rowGenerator)
        {
            _rowGenerator = rowGenerator;
        }


        public Coupon GenerateCoupon()
        {
            var coupon = new Coupon();
            coupon.CreationDate = DateTimeOffset.Now;

            var rowCount = 2; //TODO: Get this from config. Hardcoded for now.
            var rows = new Row[rowCount];

            for (var i = 0; i < rowCount; i++)
            {
                rows[i] = _rowGenerator.GenerateRow(5); //TODO: Get this from config. Hardcoded for now.
            }

            coupon.Rows = rows;

            return coupon;
        }
    }
}
