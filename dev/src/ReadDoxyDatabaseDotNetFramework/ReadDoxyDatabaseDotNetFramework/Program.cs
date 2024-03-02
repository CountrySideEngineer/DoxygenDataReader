using Doxygen.DAO;
using Doxygen.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDoxyDatabaseDotNetFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AFileDao dao = new CppSourceFileDao();
            var files = dao.GetAll();

            int index = 0;
            foreach (var item in files)
            {
                var fileItem = (FileDto)item;
                Console.WriteLine($"Index = {(index + 1),3}");
                Console.WriteLine($"\t  ID : {fileItem.Id,3}");
                Console.WriteLine($"\tNAME : {fileItem.Name}");
                Console.WriteLine($"\tPATH : {fileItem.Path}");

                var funcDao = new FunctionByFileDao();
                IEnumerable<ParamDtoBase> _funcs = funcDao.GetById(fileItem.Id);
                foreach (var funcItem in _funcs)
                {
                    Console.WriteLine($"\t\tName = {funcItem.Name}");
                }

                var globalVarDao = new GlobalVarialbeByFileDao();
                IEnumerable<ParamDtoBase> _globalVars = globalVarDao.GetById(fileItem.Id);
                foreach (var _globalVarItem in _globalVars)
                {
                    Console.WriteLine($"\t\tName = {_globalVarItem.Name}");
                }

                index++;


            }
            Console.WriteLine();
            Console.WriteLine();

            index = 0;
            var functionDao = new FunctionDao();
            var functions = functionDao.GetAll();
            foreach (var item in functions)
            {
                var funcItem = (FunctionDto)item;
                Console.WriteLine($"Index = {(index + 1),3}");
                Console.WriteLine($"\t   ID : {funcItem.Id,3}");
                Console.WriteLine($"\t TYPE : {funcItem.Type}");
                Console.WriteLine($"\t NAME : {funcItem.Name}");
                Console.WriteLine($"\tSCOPE : {funcItem.Scope}");
                Console.WriteLine($"\tDEFIN : {funcItem.Definition}");

                int argIndex = 0;
                foreach (var argItem in funcItem.Arguments ?? new List<ParamDtoBase>())
                {
                    Console.WriteLine($"\tArgIndex = {(argIndex + 1),3}");
                    Console.WriteLine($"\t\tTYPE : {argItem.Type}");
                    Console.WriteLine($"\t\tNAME : {argItem.Name}");
                    argIndex++;
                }

                int subFuncIndex = 0;
                foreach (var subFunc in funcItem.SubFunctions ?? new List<FunctionDto>())
                {
                    Console.WriteLine($"\tSubFunc = {(subFuncIndex + 1),3}");
                    Console.WriteLine($"\t\t   ID : {subFunc.Id,3}");
                    Console.WriteLine($"\t\t TYPE : {subFunc.Type}");
                    Console.WriteLine($"\t\t NAME : {subFunc.Name}");
                    subFuncIndex++;
                }

                int globalVarIndex = 0;
                foreach (var glovalVar in funcItem.GlobalVariables ?? new List<ParamDtoBase>())
                {
                    Console.WriteLine($"\tGlobal variable = {(globalVarIndex + 1),3}");
                    Console.WriteLine($"\t\t   ID : {glovalVar.Id,3}");
                    Console.WriteLine($"\t\t TYPE : {glovalVar.Type}");
                    Console.WriteLine($"\t\t NAME : {glovalVar.Name}");
                    globalVarIndex++;
                }
                Console.WriteLine();

                index++;
            }

            return;
        }
    }
}
