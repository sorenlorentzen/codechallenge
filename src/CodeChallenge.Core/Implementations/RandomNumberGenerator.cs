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
            number = Math.Abs(number + 1) % maxInclusive;
            return number;
        }
    }
}
