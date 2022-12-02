using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block
{
    public static class ECB
    {
        public static List<int> Code(List<int> key, List<int> message, int blockLength)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < message.Count; i += blockLength)
            {
                var block = message.GetRange(i, blockLength);
                block = CommonMethods.SzyfrStrumieniowy(key.GetRange(i, blockLength), block);
                result.AddRange(block);
            }
            return result;
        }
    }
}
