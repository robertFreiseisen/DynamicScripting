using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Jint;
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
            var engine = new Jint.Engine()
                    .SetValue("log", new Action<object>(Console.WriteLine));

            engine.Execute(@"
                            function myFunction() {
                                return 42;
                            }
                            log(myFunction());");

        }
        public void JavascriptSum()
        {
            var engine = new Jint.Engine()
                    .SetValue("log", new Action<object>(Console.WriteLine));

            engine.Execute(@"
                            function mySum(x, y) {
                                return x + y;
                            }
                            log(mySum(3,3));");

        }
        #endregion
    }
}
