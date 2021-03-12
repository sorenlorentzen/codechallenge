using CodeChallenge.Core.Implementations;
using CodeChallenge.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CodeChallenge.Core.Tests
{
    [TestClass]
    public class RowGeneratorTests
    {
        [TestMethod]
        public void TestNumbersArrayWillBePopulatedWithCorrectColsCount()
        {
            var config = new Configuration { ColumnsInRow = 12, MaxNumber = 40 };

            var numberGenerator = new SequentialNumberGenerator();

            var rowGenerator = new RowGenerator(config, numberGenerator);
            
            var row = rowGenerator.GenerateRow();
            Assert.AreEqual(config.ColumnsInRow, row.Numbers.Length);
        }

    }
}
