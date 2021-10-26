using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Quipu.CodeGen
{
    class Program
    {
        private const string COREDIRECTORY = "\\Quipu.Core";
        private const string SERVICEDIRECTORY = "\\BLL";
        private const string CONTROLLERDIRECTORY = "\\Controllers";

        static void Main(string[] args)
        {
            Type[] domainModelTypes = GetDomainModels();
            string serviceDirectory = GetSolutionDirectory() + COREDIRECTORY + SERVICEDIRECTORY;
            string controllerDirectory = GetSolutionDirectory() + COREDIRECTORY + CONTROLLERDIRECTORY;
            if (Directory.Exists(serviceDirectory))
            {
                var modelServiceBuilder = new ModelServiceBuilder(serviceDirectory,
                                                                  domainModelTypes);
                modelServiceBuilder.Build();

                var modelControllerBuilder = new ModelControllerBuilder(controllerDirectory,
                                                                        domainModelTypes);
                modelControllerBuilder.Build();
            }

        }

        private static string GetSolutionDirectory()
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;

            return projectDirectory;
        }


        private static Type[] GetDomainModels()
        {
            return typeof(QContext)
                         .GetProperties()
                         .Where(prop => prop.PropertyType.IsGenericType)
                         .Where(prop => prop.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                         .Select(prop => prop.PropertyType.GenericTypeArguments.First())
                         .Distinct()
                         .ToArray();
        }
    }
}
