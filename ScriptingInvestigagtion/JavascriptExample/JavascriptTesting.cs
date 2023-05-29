using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using JavaScriptEngineSwitcher.Jint;
using Jint;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaScript
{
    [MarkdownExporter,
        HtmlExporter,
        SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 5, targetCount: 5, id: "FastAndDirtyJob")]
    public class JavascriptTesting
    {
        [Benchmark]
        public void TestJavascriptSimple() => JavascriptSimple();

        [Benchmark]
        public void TestJavaScriptSum() => JavascriptSum();

        #region JavaScriptFunctions
        public void JavascriptSimple()
        {
            var engine = new JintJsEngine();
            engine.Execute("var consoleOutput = [];");
            engine.Execute(@"
                                var console = {
                                    log: function() {
                                        consoleOutput.push(Array.from(arguments).join(' '));
                                    }
                                };
                            ");

            engine.Execute(@"
                            function myFunction() {
                                return 42;
                            }
                            console.log(myFunction());");

            string jsonOutput = engine.Evaluate<string>("JSON.stringify(consoleOutput)");

            if (jsonOutput != null)
            {
                List<string>? logs = JsonConvert.DeserializeObject<List<string>>(jsonOutput);

                if (logs != null)
                {
                    foreach (var item in logs)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
        public void JavascriptSum()
        {
            var engine = new JintJsEngine();
            engine.Execute("var consoleOutput = [];");
            engine.Execute(@"
                                var console = {
                                    log: function() {
                                        consoleOutput.push(Array.from(arguments).join(' '));
                                    }
                                };
                            ");

            engine.Execute(@"
                            function mySum(int x, int y) {
                                return x+y;
                            }
                            console.log(mySum(3,3));");

            string jsonOutput = engine.Evaluate<string>("JSON.stringify(consoleOutput)");

            if (jsonOutput != null)
            {
                List<string>? logs = JsonConvert.DeserializeObject<List<string>>(jsonOutput);

                if (logs != null)
                {
                    foreach (var item in logs)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
        #endregion
    }
}
