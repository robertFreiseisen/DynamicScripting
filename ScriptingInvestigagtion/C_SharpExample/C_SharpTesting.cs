using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpExample
{
    [MarkdownExporter,
        HtmlExporter,
        SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 5, targetCount: 5, id: "FastAndDirtyJob")]
    public class C_SharpTesting
    {
        [Benchmark]
        public void TestC_Sharp_Simple() => ReturnNumber();

        [Benchmark]
        public void TestC_Sharp_Sum() => MySum();

        #region C_SharpFunctions
        public static async void ReturnNumber()
        {
            var state = await CSharpScript.RunAsync("return 42;");
            Console.WriteLine(state.ReturnValue);
        }
        public static async void MySum()
        {
            var state = await CSharpScript.RunAsync("return 3 + 3;");
            Console.WriteLine(state.ReturnValue);
        }
        #endregion
    }
}
