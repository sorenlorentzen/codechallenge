using CodeChallenge.Core.Models;
using System;

namespace CodeChallenge.Core.Generators
{
    public interface IRowGenerator
    {
        Row GenerateRow();
    }


    public class RowGenerator : IRowGenerator
    {
        public Row GenerateRow()
        {
            throw new NotImplementedException();
        }
    }


}
