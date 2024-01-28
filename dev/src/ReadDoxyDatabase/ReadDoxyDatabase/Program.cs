// See https://aka.ms/new-console-template for more information
using Doxygen.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Diagnostics.Contracts;
using System.IO.Enumeration;

using (var dbContext = new DoxygenDbContext())
{
    dbContext.Database.EnsureCreated();

    //var entities = dbContext.PathModels;

    //foreach (var entity in entities)
    //{
    //    Console.WriteLine($"rowid = {entity.RowId, 4:G}, " +
    //        $"type = {entity.Type, 4:G}, " +
    //        $"local = {entity.Local,4:G}, " +
    //        $"found = {entity.Found,4:G}, " +
    //        $"name = {entity.Name}"
    //        );
    //}

    var pathModels = dbContext.PathModels;
    var compoundDefs = dbContext.CompoundDefModels;
    var filesCollection = compoundDefs.Join(
        pathModels,
        compound => compound.FileId,
        path => path.RowId,
        (compound, path) => new
        {
            RowId = compound.RowId,
            Name = compound.Name,
            Path = path.Name,
            Kind = compound.Kind
        }
        )
        .Where(_ => 
            (_.Kind.Equals("file") && 
            _.Path.Substring(_.Path.Length - 3, 3).ToLower().Equals("cpp"))
        );

    foreach (var fileItem in filesCollection)
    {
        Console.WriteLine($"ID = {fileItem.RowId, 4} " +
            $"NAME:{fileItem.Name, -32}" +
            $"PATH:{fileItem.Path}");
    }

    //var compoundRefs = dbContext.CompoundRefModels;
    //var contains = dbContext.ContainsModels;
    //var includes = dbContext.IncludesModels;
    //var members = dbContext.MemberModels;
    //var memberDefs = dbContext.MemberDefModels;
    //var memberDefParams = dbContext.MemberDefParamModels;
    //var metas = dbContext.MetaModels;
    //var paramModels = dbContext.ParamModels;
    //var paths = dbContext.PathModels;
    //var refIds = dbContext.RefIdModels;
    //var reimplements = dbContext.ReimplementsModels;
    //var xrefs = dbContext.XRefsModels;
}
