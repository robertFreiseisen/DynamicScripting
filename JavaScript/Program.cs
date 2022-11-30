using System;
using Jint;
using Jint.Parser;

namespace JavaScript
{
    class Program
    {
        public static void Main(string[] args)
        {
            var engine = new Engine()
                .SetValue("log", new Action<object>(Console.WriteLine));

            engine.Execute(@"
                            function myFunction() {
                                return 42;
                            }
                            log(myFunction());");

            Console.ReadKey();
        }
    }
}