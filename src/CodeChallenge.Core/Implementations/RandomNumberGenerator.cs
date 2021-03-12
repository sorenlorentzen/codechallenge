using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Implementations
{
    public interface INumberGenerator
    {
        int GenerateNumber(int maxInclusive);
    }


    public class RandomNumberGenerator : INumberGenerator
    {
        public int GenerateNumber(int maxInclusive)
        {
            using RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            var array = new byte[4]; //int is four bytes in .net 5

            rng.GetBytes(array);

            var number = BitConverter.ToInt32(array, 0);
            if (number != int.MaxValue)
            {
                number++;
            }
            number = Math.Abs(number);
            number %= maxInclusive;
            return number;
        }
    }

    public class RandomNextNumberGenerator : INumberGenerator
    {
        private static Random _random = new(); //WE're using a shared instance to make sure we dont create instances with equal seed

        public int GenerateNumber(int maxInclusive)
        {
            var i = _random.Next(maxInclusive);
            return i;
        }
    }
}
