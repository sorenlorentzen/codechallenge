using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Generators
{
    public interface IRandomNumberGenerator
    {
        int GenerateRandomNumber(int maxInclusive);
    }


    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int GenerateRandomNumber(int maxInclusive)
        {
            using RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            var array = new byte[4]; //int is four bytes in .net 5

            rng.GetBytes(array);

            var number = BitConverter.ToInt32(array, 0);
            number = Math.Abs(number + 1) % maxInclusive;
            return number;
        }
    }
}
