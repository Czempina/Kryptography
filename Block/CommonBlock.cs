using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block
{
    public class CommonBlock
    {
        public static List<int> FillWithO(List<int> bits, int blockLength) {
            int Onumbers = blockLength - bits.Count % blockLength;
            while (Onumbers > 0)
            {
                bits.Add(0);
                Onumbers--;
            }
            return bits;
        }
        
}
}
