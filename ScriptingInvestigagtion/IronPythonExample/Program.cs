using IronPython.Hosting;

var engine = Python.CreateEngine();
var scope = engine.CreateScope();
var source = engine.CreateScriptSourceFromFile("test.py");
source.Execute(scope);
var test = scope.GetVariable("test");
Console.WriteLine(test);