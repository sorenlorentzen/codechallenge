using CodeChallenge.Core.Models;
using System;
using System.Globalization;
using System.Linq;

namespace CodeChallenge.Core.Implementations
{
    public interface IRowGenerator
    {
        Row GenerateRow();
    }


    public class RowGenerator : IRowGenerator
    {
        private readonly Configuration _configuration;
        private readonly INumberGenerator _numberGenerator;

        public RowGenerator(Configuration configuration, INumberGenerator numberGenerator)
        {
            _configuration = configuration;
            _numberGenerator = numberGenerator;
        }

        public Row GenerateRow()
        {
            int[] numbers;

            do
            {
                numbers = GenerateNumbersInternal(_configuration.ColumnsInRow, _configuration.MaxNumber);  

            } while (numbers.Distinct().Count() != _configuration.ColumnsInRow);

            //Order by value
            Array.Sort(numbers);

            var row = new Row
            {
                Numbers = numbers
            };
            return row;
        }

        private int[] GenerateNumbersInternal(int colsCount, int maxNumberInclusive)
        {
            var numbers = new int[colsCount];
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = _numberGenerator.GenerateNumber(maxNumberInclusive);
            }
            return numbers;
        }


    }


}
