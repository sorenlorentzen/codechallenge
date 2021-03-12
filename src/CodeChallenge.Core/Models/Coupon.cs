using CodeChallenge.Core.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Models
{
    public class Coupon
    {
        public DateTimeOffset CreationDate { get; set; }
        public Row[] Rows { get; set; }


        public Coupon()
        {
            this.CreationDate = DateTimeOffset.Now;
        }
    }
}
