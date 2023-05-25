using BenchmarkDotNet.Running;
using JavaScriptEngineSwitcher.Jint;
using Newtonsoft.Json;
using System;

namespace JavaScript
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
