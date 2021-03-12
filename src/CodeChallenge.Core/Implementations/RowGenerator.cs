using CodeChallenge.Core.Models;
using System;
using System.Globalization;
using System.Linq;

namespace CodeChallenge.Core.Implementations
{
    public interface IRowGenerator
    {
        Row GenerateRow(int colsCount);
    }


    public class RowGenerator : IRowGenerator
    {
        private readonly INumberGenerator _numberGenerator;

        public RowGenerator(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public Row GenerateRow(int colsCount)
        {
            int[] numbers;

            do
            {
                numbers = GenerateNumbersInternal(colsCount, 40); //TODO: Get from config. Hardcoded this value for now. 

            } while (numbers.Distinct().Count() != colsCount);

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
