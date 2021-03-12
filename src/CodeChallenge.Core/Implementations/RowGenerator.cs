using CodeChallenge.Core.Models;
using System;

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
            var row = new Row();

            var numbers = new int[colsCount];
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = _numberGenerator.GenerateNumber(40); //TODO: Get from config. Hardcoded this value for now. 
            }
            row.Numbers = numbers;
            return row;
        }


    }


}
