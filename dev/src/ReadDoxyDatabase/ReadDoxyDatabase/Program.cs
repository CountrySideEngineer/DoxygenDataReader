// See https://aka.ms/new-console-template for more information
using Doxygen.DAO;
using Doxygen.DTO;

AFileDao dao = new CppSourceFileDao();
var files = dao.GetAll();

Console.WriteLine("- SOURCE CODE FILES -");
foreach (var item in files.Select((value, index) => new { value, index }))
{
    var fileItem = (FileDto)item.value;
	Console.WriteLine($"Index = {(item.index + 1),3}");
	Console.WriteLine($"{"ID",24} : {fileItem.Id,3}");
	Console.WriteLine($"{"FILE NAME",24} : {fileItem.Name}");
	Console.WriteLine($"{"FILE PATH",24} : {fileItem.Path}");

    var funcDao = new FunctionByFileDao();
	Console.WriteLine($"{"FUNCTION in THE FILE",24} : ");
	IEnumerable<ParamDtoBase> _funcs = funcDao.GetById(fileItem.Id);
	if (_funcs.Any())
	{
		foreach (var funcItem in _funcs.Select((value, index) => new { value, index }))
		{
			Console.WriteLine($"{(funcItem.index + 1),32} : {funcItem.value.Name}");
		}
	}

	var globalVarDao = new GlobalVarialbeByFileDao();
    IEnumerable<ParamDtoBase> _globalVars = globalVarDao.GetById(fileItem.Id);
	if (_globalVars.Any())
	{
		Console.WriteLine($"{"GLOBAL VAR in THE FILE",24} : ");
		foreach (var _globalVarItem in _globalVars.Select((value, index) => new { value, index }))
		{
			Console.WriteLine($"{(_globalVarItem.index + 1),32} : {_globalVarItem.value.Name}");
		}
	}
}

Console.WriteLine();
Console.WriteLine("- FUNCTIONS -");
var functionDao = new FunctionDao();
var functions = functionDao.GetAll();
foreach (var item in functions.Select((value, index) => new {value, index}))
{
    var funcItem = (FunctionDto)item.value;
    Console.WriteLine($"Index = {(item.index + 1), 3}");
	Console.WriteLine($"{"ID",24} : {funcItem.Id,3}");
	Console.WriteLine($"{"TYPE",24} : {funcItem.Type}");
	Console.WriteLine($"{"NAME",24} : {funcItem.Name}");
	Console.WriteLine($"{"SCOPE",24} : {funcItem.Scope}");
	Console.WriteLine($"{"DEFINE",24} : {funcItem.Definition}");

	if ((null != funcItem.Arguments) && (funcItem.Arguments.Any()))
	{
        Console.WriteLine($"{"ARGUMENTS",24} : ");
        foreach (var argItem in funcItem.Arguments.Select((value, index) => new { value, index }))
		{
			Console.WriteLine($"{"ARGUMENT",32}{(argItem.index + 1)} : ");
			Console.WriteLine($"{"TYPE",40} : {argItem.value.Type}");
			Console.WriteLine($"{"NAME",40} : {argItem.value.Name}");
		}
	}

	if ((null != funcItem.SubFunctions) && (funcItem.SubFunctions.Any()))
	{
        Console.WriteLine($"{"SUBFUNCTIONS",24} : ");
        foreach (var subFunc in funcItem.SubFunctions.Select((value, index) => new {value, index}))
		{
			Console.WriteLine($"{"SUBFUNCTION",32}{(subFunc.index + 1)} : ");
			Console.WriteLine($"{"ID",40} : {subFunc.value.Id,3}");
			Console.WriteLine($"{"TYPE",40} : {subFunc.value.Type}");
			Console.WriteLine($"{"NAME",40} : {subFunc.value.Name}");
		}
	}

	if ((null != funcItem.GlobalVariables) && (funcItem.GlobalVariables.Any()))
	{
        Console.WriteLine($"{"GLOBAL VARIABLES",24} : ");
        foreach (var glovalVar in funcItem.GlobalVariables.Select((value, index) => new { value, index })) 
		{
			Console.WriteLine($"{"GLOBAL_VARIABLES",32}{(glovalVar.index + 1)}");
			Console.WriteLine($"{"ID",40} : {glovalVar.value.Id,3}");
			Console.WriteLine($"{"TYPE",40} : {glovalVar.value.Type}");
			Console.WriteLine($"{"NAME",40} : {glovalVar.value.Name}");
		}
	}
}

Console.WriteLine();
Console.WriteLine("- FUNCTIONS -");

return;