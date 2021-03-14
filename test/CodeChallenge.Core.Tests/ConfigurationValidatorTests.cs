using CodeChallenge.Core.Implementations;
using CodeChallenge.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeChallenge.Core.Tests
{
    [TestClass]
    public class ConfigurationValidatorTests
    {
        private ConfigurationValidator _validator;
        private Configuration _config;

        [TestInitialize]
        public void Init()
        {
            this._validator = new ConfigurationValidator();
            this._config = new Configuration();
        }

        [TestMethod]
        public void TestDefaultsAreValid()
        {
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnNegativeMaxNumber()
        {
            _config.MaxNumber = -1;
            _validator.Validate(_config);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnZeroMaxNumber()
        {
            _config.MaxNumber = 0;
            _validator.Validate(_config);
        }
        

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesMaxNumberLessThanColumns()
        {
            _config.MaxNumber = 7;
            _config.ColumnsInRow = 13;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesMaxNumberEqualToColumns()
        {
            _config.MaxNumber = 13;
            _config.ColumnsInRow = 13;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnNegativeLuckyNumber()
        {
            _config.LuckyNumber = -1;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnZeroLuckyNumber()
        {
            _config.LuckyNumber = 0;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnLuckyNumberHigherThanMaxNumber()
        {
            _config.LuckyNumber = 29;
            _config.MaxNumber = 23;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnNegativeColumns()
        {
            _config.ColumnsInRow = -1;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnZeroColumns()
        {
            _config.ColumnsInRow = 0;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnOneColumns()
        {
            _config.ColumnsInRow = 1;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnNegativeRows()
        {
            _config.RowsInCoupon = -1;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnZeroRows()
        {
            _config.RowsInCoupon = 0;
            _validator.Validate(_config);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExplodesOnOneRows()
        {
            _config.RowsInCoupon = 1;
            _validator.Validate(_config);
        }
    }
}
