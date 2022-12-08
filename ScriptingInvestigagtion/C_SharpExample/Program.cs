using BenchmarkDotNet.Running;
using System;

namespace C_SharpExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            Console.ReadKey();
        }
    }
}




