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

AFileDao dao = new CppSourceFileDao();
var files = dao.GetAll();

foreach (var item in files)
{
    var fileItem = (FileDto)item;
    Console.WriteLine($"ID = {fileItem.Id, 4} " +
        $"NAME:{fileItem.Name, -24}" +
        $"PATH:{fileItem.Path}");
}

var functionDao = new FunctionDao();
var functions = functionDao.GetAll();
foreach (var item in functions)
{
    var funcItem = (FunctionDto)item;
    Console.Write($"ID = {funcItem.Id,4} " +
        $"DEF:{funcItem.Type,8} {funcItem.Name,-32} " +
        $"({funcItem.Definition}) ");
        foreach (var arg in funcItem.Arguments)
    {
        Console.Write($"{ arg.Type} {arg.Name}, ");
    }
    Console.WriteLine();
}

return;