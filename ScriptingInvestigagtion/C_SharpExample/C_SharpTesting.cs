using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
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
        public void TestC_Sharp_Simple() => Console.WriteLine(ReturnNumber());

        [Benchmark]
        public void TestC_Sharp_Sum() => Console.WriteLine(MySum(3,3));

        #region C_SharpFunctions
        public static int ReturnNumber()
        {
            return 42;
        }
        public static int MySum(int x, int y)
        {
            return x + y;
        }
        #endregion
    }
}
