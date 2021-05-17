using System;

namespace SWGOHPhaseFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var API = new API();
            API.Login().GetAwaiter().GetResult();

            Console.WriteLine("Hello World!");
        }
    }
}
