// See https://aka.ms/new-console-template for more information
using Doxygen.DAO;
using Doxygen.DTO;

AFileDao dao = new CppSourceFileDao();
var files = dao.GetAll();

foreach (var item in files.Select((value, index) => new { value, index }))
{
    var fileItem = (FileDto)item.value;
	Console.WriteLine($"Index = {(item.index + 1),3}");
	Console.WriteLine($"{"ID",12} : {fileItem.Id,3}");
	Console.WriteLine($"{"FILE NAME",12} : {fileItem.Name}");
	Console.WriteLine($"{"FILE PATH",12} : {fileItem.Path}");

    var funcDao = new FunctionByFileDao();
	Console.WriteLine($"{"FUNCTION in THE FILE",24}");
	IEnumerable<ParamDtoBase> _funcs = funcDao.GetById(fileItem.Id);
	if (_funcs.Any())
	{
		foreach (var funcItem in _funcs.Select((value, index) => new { value, index }))
		{
			Console.WriteLine($"{(funcItem.index + 1),28} : {funcItem.value.Name}");
		}
	}

	var globalVarDao = new GlobalVarialbeByFileDao();
    IEnumerable<ParamDtoBase> _globalVars = globalVarDao.GetById(fileItem.Id);
	if (_globalVars.Any())
	{
		Console.WriteLine($"{"GLOBAL VAR in THE FILE",24}");
		foreach (var _globalVarItem in _globalVars.Select((value, index) => new { value, index }))
		{
			Console.WriteLine($"{(_globalVarItem.index + 1),28} : {_globalVarItem.value.Name}");
		}
	}
}

var functionDao = new FunctionDao();
var functions = functionDao.GetAll();
foreach (var item in functions.Select((value, index) => new {value, index}))
{
    var funcItem = (FunctionDto)item.value;
    Console.WriteLine($"Index = {(item.index + 1), 3}");
	Console.WriteLine($"{"ID",12} : {funcItem.Id,3}");
	Console.WriteLine($"{"TYPE",12} : {funcItem.Type}");
	Console.WriteLine($"{"NAME",12} : {funcItem.Name}");
	Console.WriteLine($"{"SCOPE",12} : {funcItem.Scope}");
	Console.WriteLine($"{"DEFINE",12} : {funcItem.Definition}");

	if ((null != funcItem.Arguments) && (funcItem.Arguments.Any()))
	{
		foreach (var argItem in funcItem.Arguments.Select((value, index) => new { value, index }))
		{
			Console.WriteLine($"{"ARGUMENT",24}{(argItem.index + 1)}");
			Console.WriteLine($"{"TYPE",28} : {argItem.value.Type}");
			Console.WriteLine($"{"NAME",28} : {argItem.value.Name}");
		}
	}

	if ((null != funcItem.SubFunctions) && (funcItem.SubFunctions.Any()))
	{
		foreach (var subFunc in funcItem.SubFunctions.Select((value, index) => new {value, index}))
		{
			Console.WriteLine($"{"SUBFUNCTION",24}{(subFunc.index + 1)}");
			Console.WriteLine($"{"ID",28} : {subFunc.value.Id,3}");
			Console.WriteLine($"{"TYPE",28} : {subFunc.value.Type}");
			Console.WriteLine($"{"NAME",28} : {subFunc.value.Name}");
		}
	}

	if ((null != funcItem.GlobalVariables) && (funcItem.GlobalVariables.Any()))
	{
		foreach (var glovalVar in funcItem.GlobalVariables.Select((value, index) => new { value, index })) 
		{
			Console.WriteLine($"{"Global variable",24}{(glovalVar.index + 1)}");
			Console.WriteLine($"{"ID",28} : {glovalVar.value.Id,3}");
			Console.WriteLine($"{"TYPE",28} : {glovalVar.value.Type}");
			Console.WriteLine($"{"NAME",28} : {glovalVar.value.Name}");
		}
	}
}

return;