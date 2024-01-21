// See https://aka.ms/new-console-template for more information
using Doxygen.DB;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

Console.WriteLine("Hello, World!");

using (var dbContext = new DoxygenDbContext())
{
    dbContext.Database.EnsureCreated();

    var entities = dbContext.PathModels;

    foreach (var entity in entities)
    {
        Console.WriteLine($"rowid = {entity.RowId, 4:G}, " +
            $"type = {entity.Type, 4:G}, " +
            $"local = {entity.Local,4:G}, " +
            $"found = {entity.Found,4:G}, " +
            $"name = {entity.Name}"
            );
    }
}
