using System;

namespace CodeChallenge.Core.Models
{
    public class Coupon
    {
        public DateTimeOffset CreationDate { get; set; }
        public Row[] Rows { get; set; }

    }
}
