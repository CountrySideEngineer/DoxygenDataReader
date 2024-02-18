// See https://aka.ms/new-console-template for more information
using Doxygen.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Diagnostics.Contracts;
using System.IO.Enumeration;
using Doxygen.DAO;
using Doxygen.DTO;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

AFileDao dao = new CppSourceFileDao();
var files = dao.GetAll();

int index = 0;
foreach (var item in files)
{
    var fileItem = (FileDto)item;
    Console.WriteLine($"Index = {(index + 1), 3}");
    Console.WriteLine($"\t  ID : {fileItem.Id, 3}");
    Console.WriteLine($"\tNAME : {fileItem.Name}");
    Console.WriteLine($"\tPATH : {fileItem.Path}");
}
Console.WriteLine();
Console.WriteLine();

index = 0;
var functionDao = new FunctionDao();
var functions = functionDao.GetAll();
foreach (var item in functions)
{
    var funcItem = (FunctionDto)item;
    Console.WriteLine($"Index = {(index + 1), 3}");
    Console.WriteLine($"\t   ID : {funcItem.Id, 3}");
    Console.WriteLine($"\t TYPE : {funcItem.Type}");
    Console.WriteLine($"\t NAME : {funcItem.Name}");
    Console.WriteLine($"\tSCOPE : {funcItem.Scope}");
    Console.WriteLine($"\tDEFIN : {funcItem.Definition}");

    int argIndex = 0;
    foreach (var argItem in funcItem.Arguments ?? new List<ParamDtoBase>())
    {
        Console.WriteLine($"\tArgIndex = {(argIndex + 1), 3}");
        Console.WriteLine($"\t\tTYPE : {argItem.Type}");
        Console.WriteLine($"\t\tNAME : {argItem.Name}");
        argIndex++;
    }

    int subFuncIndex = 0;
    foreach (var subFunc in funcItem.SubFunctions ?? new List<FunctionDto>())
    {
        Console.WriteLine($"\tSubFunc = {(subFuncIndex + 1), 3}");
        Console.WriteLine($"\t\t   ID : {subFunc.Id, 3}");
        Console.WriteLine($"\t\t TYPE : {subFunc.Type}");
        Console.WriteLine($"\t\t NAME : {subFunc.Name}");
        subFuncIndex++;
    }

    int globalVarIndex = 0;
    foreach (var glovalVar in funcItem.GlobalVariables ?? new List<ParamDtoBase>())
    {
        Console.WriteLine($"\tGlobal variable = {(globalVarIndex + 1), 3}");
        Console.WriteLine($"\t\t   ID : {glovalVar.Id,3}");
        Console.WriteLine($"\t\t TYPE : {glovalVar.Type}");
        Console.WriteLine($"\t\t NAME : {glovalVar.Name}");
        globalVarIndex++;
    }



    Console.WriteLine();

    index++;
}

return;