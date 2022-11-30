using BenchmarkDotNet.Attributes;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using NLua;

namespace IronPythonVsLua
{
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class IronPythonVsLua
    {
        #region IronPython
        [Benchmark]
        public void TestIronPython() => IronPythonSimple();
        [Benchmark]
        public void TestIronPythonSum() => IronPythonSum();
        [Benchmark]
        public void TestIronPythonPassDotNetObjectsAndCallFunction() => IronPythonPassDotNetObjectsAndCallFunction();
       
        #endregion

        private readonly Lua state = new Lua();
        private readonly ScriptEngine engine = Python.CreateEngine();
        #region Lua
        [Benchmark]
        public void TestLua() => LuaSimple();
        [Benchmark]
        public void TestLuaSum() => LuaSum();
        [Benchmark]
        public void TestLuaPassDotNetObjectsAndCallFunction() => LuaPassDotNetObjectAndCallFunction();
        #endregion

        #region IronPythonMethods
        public void IronPythonSimple()
        {
            var scope = engine.CreateScope();
            var source = engine.CreateScriptSourceFromString("def fun():\r\n\treturn 42\r\n\r\n\r\ntest = fun()");
            source.Execute(scope);
            var test = scope.GetVariable("test");
            Console.WriteLine(test);
        }

        public void IronPythonSum()
        {
            var scope = engine.CreateScope();
            var source = engine.CreateScriptSourceFromString("def sum(x,y): \r\n\t return x+ y\r\n\r\n\r\n result=sum(3,3)");
            source.Execute(scope);
            var result = scope.GetVariable("result");
            Console.WriteLine(result);
        }

        public void IronPythonPassDotNetObjectsAndCallFunction() 
        {
            var scope = engine.CreateScope();
            var obj = new SomeClass();
            scope.SetVariable("obj", obj);
            var source = engine.CreateScriptSourceFromString(SetPythonScript());
            source.Execute(scope);
            var result = scope.GetVariable("result");
            Console.WriteLine(result);
        }
        #endregion

        #region LuaMethods
        public void LuaPassDotNetObjectAndCallFunction()
        {
            var obj = new SomeClass();
            state["obj"] = obj;
            state.DoString (@"result=obj:Func1()");
            var result = state["result"];
            Console.WriteLine(result);
        }

        private static string SetPythonScript()
        {
            string s = "";
            s += "import clr" + "\r\n";
            s += "result=obj.Func1() " + "\r\n";
            return s;
        }

        public void LuaSimple()
        {
            state.DoString("function fun() \r\n\t  return 42 \r\n end \r\n test=fun()");
            var test = state["test"];
            Console.WriteLine(test);
        }

        public void LuaSum()
        {


            state.DoString("function sum(x,y) \r\n\t return x+y \r\n end \r\n result=sum(3,3)");
            var result = state["result"];
            Console.WriteLine(result);
        }

        #endregion
    }
}
