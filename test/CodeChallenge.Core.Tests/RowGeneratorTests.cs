using CodeChallenge.Core.Implementations;
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
            var numberGenerator = Substitute.For<INumberGenerator>();
            numberGenerator.GenerateNumber(Arg.Any<int>()).Returns(20);

            var rowGenerator = new RowGenerator(numberGenerator);
            var colsCount = 12;
            
            var row = rowGenerator.GenerateRow(colsCount);
            Assert.AreEqual(colsCount, row.Numbers.Length);
        }

    }
}
