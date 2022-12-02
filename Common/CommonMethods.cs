using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class CommonMethods
    {
        public static void SaveToFile(List<int> bits, string filename)
        {
            File.WriteAllText($"../{filename}.txt", "");
            Console.WriteLine();
            Console.WriteLine($"{filename}:");
            foreach (int bit in bits)
            {
                Console.Write(bit);
                File.AppendAllText($"../{filename}.txt", bit.ToString());
            }
        }
        public static List<int> ReadFile(string filename)
        {
            List<int> bits = new List<int>();
            foreach (char ch in File.ReadAllText($"../{filename}.txt"))
            {
                bits.Add((int)ch);
            }
            return bits;
        }
        public static List<int> SzyfrStrumieniowy(List<int> key, List<int> message)
        {
            if (key.Count == message.Count)
            {
                List<int> result = new List<int>();
                for (int i = 0; i < key.Count; i++)
                {
                    result.Add(key[i] != message[i] ? 1 : 0);
                }
                return result;
            }
            return null;
        }
        public static bool coprime(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            if ((a | b) == 1) { return true; }
            else { return false; }
        }

        public static bool isPrime(int number)
        {
            if (number == 1 || number == 2 || number == 3)
            {
                return true;
            }
            else if (number == 4)
            {
                return false;
            }
            else
            {
                for (int i = 3; number > i; i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                    if (i + 1 == number) { return true; }
                }
            }
            return false;
        }
        public static bool isCongruentNumber(int number)
        {
            if ((number - 3) % 4 == 0)
            {
                return true;
            }
            else { return false; }
        }

        public static void PrintPrimeNumbers(int max)
        {
            for (int i = 2; i < max; i++)
            {
                if (CommonMethods.isPrime(i)) { Console.WriteLine(i); }
            }
        }

        public static void printPrimeAndCongruentNumbers(int max)
        {
            for (int i = 2; i < max; i++)
            {
                if (CommonMethods.isPrime(i) && isCongruentNumber(i)) { Console.WriteLine(i); }
            }
        }

        public static int findX(int p, int q)
        {
            if (CommonMethods.isPrime(p) && CommonMethods.isPrime(q) && isCongruentNumber(q) && isCongruentNumber(p))
            {
                Random random = new Random();

                int n = p * q;
                int x = 1;
                while (coprime(n, x))
                {
                    x = random.Next(0, n);
                    return x;
                }
            }
            return -1;
        }
    }
}
