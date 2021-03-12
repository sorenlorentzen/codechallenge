using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Models
{
    public class Configuration
    {
        [JsonPropertyName("rowsInCoupon")]
        public int RowsInCoupon { get; set; }

        [JsonPropertyName("columnsInRow")]
        public int ColumnsInRow { get; set; }

        [JsonPropertyName("luckyNumber")]
        public int LuckyNumber { get; set; }

        [JsonPropertyName("maxNumber")]
        public int MaxNumber { get; set; }

        [JsonPropertyName("useRandomNext")]
        public bool UseRandomNext { get; set; }
    }
}
