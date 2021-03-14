using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Implementations
{

    public class ConfigurationValidator
    {
        public void Validate(Configuration config)
        {
            if (config.RowsInCoupon <= 1) throw new Exception($"{nameof(Configuration.RowsInCoupon)} must be greater than 1");
            if (config.ColumnsInRow <= 1) throw new Exception($"{nameof(Configuration.ColumnsInRow)} must be greater than 1");
            if (config.MaxNumber <= config.ColumnsInRow) throw new Exception($"{nameof(Configuration.MaxNumber)} must be greater than {nameof(Configuration.ColumnsInRow)}");
            if (config.LuckyNumber < 1 || config.LuckyNumber > config.MaxNumber) throw new Exception($"{nameof(Configuration.LuckyNumber)} must be between 1 and {nameof(Configuration.MaxNumber)}");
        }
    }
}
