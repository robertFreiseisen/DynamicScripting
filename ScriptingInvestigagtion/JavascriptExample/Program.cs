using BenchmarkDotNet.Running;
using System;

namespace JavaScript
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*var engine = new Engine()
                .SetValue("log", new Action<object>(Console.WriteLine));

            engine.Execute(@"
                            function myFunction() {
                                return 42;
                            }
                            log(myFunction());");*/
        
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            Console.ReadKey();
        }
    }
}
