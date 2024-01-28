// See https://aka.ms/new-console-template for more information
using Doxygen.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Diagnostics.Contracts;
using System.IO.Enumeration;
using Doxygen.DAO;

AFileDao dao = new CppSourceFileDao();
var files = dao.GetAll();

foreach (var fileItem in files)
{
    Console.WriteLine($"ID = {fileItem.Id, 4} " +
        $"NAME:{fileItem.Name, -24}" +
        $"PATH:{fileItem.Path}");
}
