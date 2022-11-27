using NLua;

var state = new Lua();
state.DoFile("test.lua");
var test = state["test"];
Console.WriteLine(test);