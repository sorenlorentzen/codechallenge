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
        private readonly Configuration _configuration;
        private readonly IRowGenerator _rowGenerator;

        public CouponGenerator(Configuration configuration, IRowGenerator rowGenerator)
        {
            _configuration = configuration;
            _rowGenerator = rowGenerator;
        }


        public Coupon GenerateCoupon()
        {
            var coupon = new Coupon();
            coupon.CreationDate = DateTimeOffset.Now;

            var rowCount = _configuration.RowsInCoupon;
            var rows = new Row[rowCount];

            for (var i = 0; i < rowCount; i++)
            {
                rows[i] = _rowGenerator.GenerateRow(); 
            }

            coupon.Rows = rows;

            return coupon;
        }
    }
}
