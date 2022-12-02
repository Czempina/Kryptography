using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ConsoleApp2;

namespace ConsoleApp2
{
    public class BBS
    {
        private int p { get; set; }
        private int q { get; set; }
        private int n { get; set; }
        private int seed { get; set; }
        private List<int> generatedValues = new List<int>();
        Random random = new Random();
        public BBS(int p, int q)
        {
            this.p = p;
            this.q = q;
            if (p > 0 && q > 0)
            {
                n = p * q;
                setSeed();
            }
        }

        private void setSeed()
        {
            Random random = new Random();
            while (!CommonMethods.coprime(n, seed) && seed < 1)
            {
                seed = random.Next(0, n - 1);
            }
        }

        private int generateValue()
        {
            if (p > 0 && q > 0)
            {
                int x = 0;
                while (!CommonMethods.coprime(n, x))
                {
                    x = random.Next(0,n);
                }
                return (int)(Math.Pow(x, 2) % n);
            }
            return -1;
        }

        public List<int> generateBits(int amount)
        {
            if (p == q || n == 0)
            {
                return null;
            }
            else
            {
                List<int> bits = new List<int>();
                amount += 1;
                for (int i = 0; i < amount-1; i++)
                {
                    var generatedValue = generateValue();
                    generatedValues.Add(generatedValue);
                    if (generatedValue % 2 == 0)
                    { bits.Add(0); }
                    else
                    { bits.Add(1); }
                }
                return bits;
            }
        }
    }
}
