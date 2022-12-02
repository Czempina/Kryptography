using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Tests
    {
        public bool SingleBit(List<int> bits)
        {
            int minValue = 9725;
            int maxValue = 10275;
            int countBit1 = 0;

            foreach (var bit in bits)
            {
                if (bit == 1)
                    countBit1++;
            }

            if (countBit1 > minValue && countBit1 < maxValue)
            {
                Console.WriteLine($"True: {countBit1}");
                return true;
            }
            else
            {
                Console.WriteLine($"False: {countBit1}");
                return false;
            }
        }

        public bool Series(List<int> bits)
        {
            int index = 0;
            int nextIndex = 1;
            int longestSeries = 0;
            int currentSeries = 1;
            bool breakSeries = false;
            int value = bits[0];

            foreach (var bit in bits)
            {
                if (nextIndex < bits.Count)
                {
                    if (value == bits[nextIndex])
                    {
                        currentSeries++;
                        if (currentSeries > longestSeries)
                        {
                            longestSeries = currentSeries;
                            value = bit;
                        }
                        if (value != bits[nextIndex])
                        {
                            currentSeries = 1;
                            value = bits[nextIndex];
                        }
                    }
                }
                index++;
                nextIndex++;
            }
            Console.WriteLine($"Longest series: {longestSeries}, value: {value}");
            return true;
        }

        public bool LongSeries(List<int> bits)
        {
            int prev;
            int next;
            int first = 0;
            int second = 0;
            int third = 0;
            int fourth = 0;
            for (int i = 1; i < bits.Count; i++)
            {
                prev = bits[i - 1];
                next = bits[i];
                if (prev == 0 && next == 0)
                    first++;
                if (prev == 0 && next == 1)
                    second++;
                if (prev == 1 && next == 0)
                    third++;
                if (prev == 1 && next == 1)
                    fourth++;
            }
            Console.WriteLine($"First: {first} second:{second} third: {third} fourth: {fourth}");
            return true;
        }

        public bool Poker(List<int> bits)
        {
            int max = 0;
            int count = 0;
            var sBits = bits;
            List<int> values = new List<int>();
            for (int i = 3; i < sBits.Count; i += 4)
            {
                var result = 0;
                if (sBits[i - 3] == 1) result += 1;
                if (sBits[i - 2] == 1) result += 2;
                if (sBits[i - 1] == 1) result += 4;
                if (sBits[i] == 1) result += 8;
                values.Add(result);
            }
            double x = 0;
            for (int i = 0; i < 16; i++)
            {
                var t = values.Where(x => x == i).Count();
                x += Math.Pow(t, 2);
            }
            x *= 16;
            x /= bits.Count;
            x *= 4;
            Console.WriteLine(x - (bits.Count / 4));

            if (x - (bits.Count / 4) > 2.16 && x - (bits.Count / 4) < 46.17)
            {
                return true;
            }
            return false;
        }
    }
}
