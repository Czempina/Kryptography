using Common;
using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block
{
    public static class CBC
    {
        public static List<int> Code(List<int> key, List<int> message, int blockLength)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < message.Count; i += blockLength)
            {
                var block = message.GetRange(i, blockLength);
                var previousBlock = i > 0 ? result.GetRange(i - blockLength, blockLength) : key.GetRange(i, blockLength);
                block = CommonMethods.SzyfrStrumieniowy(previousBlock, block);
                result.AddRange(block);
            }
            return result;
        }
        public static List<int> Decode(List<int> key, List<int> message, int blockLength)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < message.Count; i += blockLength)
            {
                var block = message.GetRange(i, blockLength);
                var previousBlock = i > 0 ? message.GetRange(i - blockLength, blockLength) : key.GetRange(i, blockLength);
                block = CommonMethods.SzyfrStrumieniowy(previousBlock, block);
                result.AddRange(block);
            }
            return result;
        }
    }
}
