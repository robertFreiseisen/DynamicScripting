using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using C_SharpExample;
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
        [Benchmark]
        public void TestJavascriptDotNetObjects() => DotNetObjects();

        #region JavaScriptFunctions
        public void JavascriptSimple()
        {
            var engine = new JintJsEngine();           
            engine.Execute(@"
                            function myFunction() {
                                return 42;
                            }");           
        }
        public void JavascriptSum()
        {
            var engine = new JintJsEngine();

            engine.Execute(@"
                            function mySum(x,y) {
                                return x+y;
                            }
                            var x = mySum(3,3);");
        }
        public void DotNetObjects()
        {
            var engine = new JintJsEngine();
            var obj = new Student("Hans", 18);
            var student = JsonConvert.SerializeObject(obj);
            engine.SetVariableValue("student", student);           
        }
        #endregion
    }
}
