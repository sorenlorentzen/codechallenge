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
        public int RowsInCoupon { get; set; } = 2;

        [JsonPropertyName("columnsInRow")]
        public int ColumnsInRow { get; set; } = 2;

        [JsonPropertyName("luckyNumber")]
        public int LuckyNumber { get; set; } = 1;

        [JsonPropertyName("maxNumber")]
        public int MaxNumber { get; set; } = 3;

        [JsonPropertyName("useRandomNext")]
        public bool UseRandomNext { get; set; } = false;
    }
}
