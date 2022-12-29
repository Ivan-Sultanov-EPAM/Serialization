using System;

namespace JsonSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal number = 1.1759999999999999m;
            var result = Math.Round(number, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine(result);
        }
    }
}
