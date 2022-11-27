using BenchmarkDotNet.Attributes;
using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPythonVsLua
{
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class IronPythonVsLua
    {
        [Benchmark]
        public void TestIronPython() => IronPython();

        public void IronPython()
        {
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var source = engine.CreateScriptSourceFromString("def function():\r\n\treturn 42\r\n\r\n\r\ntest = function()");
            source.Execute(scope);
            var test = scope.GetVariable("test");
            Console.WriteLine(test);
        }
    }
}
