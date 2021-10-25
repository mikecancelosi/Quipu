using Quipu.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quipu.CodeGen
{
    public class ModelServiceBuilder
    {
        private string _serviceDirectoryPath;
        private Type[] _domainModelTypes;

        public ModelServiceBuilder(string serviceDirectoryPath,
                                   Type[] domainModelTypes)
        {
            _serviceDirectoryPath = serviceDirectoryPath;
            _domainModelTypes = domainModelTypes;
        }

        public async void Build()
        {
            foreach (Type modelType in _domainModelTypes)
            {
                // Only build the service if the service doesn't already exist. 
                // We only want to help with initialization of a new domain model, 
                // we don't want to impede custom requirements for model services.
                if (!ServiceAlreadyExists(modelType))
                {
                    string fileContents = BuildFileContents(modelType);
                    string filePath = GetFilePath(modelType);
                    await File.WriteAllTextAsync(filePath, fileContents);
                }
            }
        }

        private bool ServiceAlreadyExists(Type modelType)
        {
            string path = GetFilePath(modelType);
            return File.Exists(path);
        }

        private string GetFilePath(Type modelType)
        {
            return _serviceDirectoryPath + "/" + modelType.Name + "Service.cs";
        }

        /// <summary>
        /// Build file contents with base CRUD operations
        /// Note: You will have to crtl k + d to set up proper spacing.
        /// TODO: Build file contents without improper spacing
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        private static string BuildFileContents(Type modelType)
        {
            string output = "";

            string modelName = modelType.Name;
            string serviceName = modelName + "Service";
            string dbSetName = modelName + "s";
            if (modelType == typeof(TaskStatusCategory))
            {
                dbSetName = "TaskStatusCategories";
            }
            else if(modelType == typeof(Settings))
            {
                dbSetName = "Settings";
            }

            output += "using System.Collections.Generic;\n" +
                      "using System.Linq;\n" +
                      "using System.Threading.Tasks;\n" +
                      "using Microsoft.AspNetCore.Mvc;\n" +
                      "using Microsoft.EntityFrameworkCore;\n" +
                      "using Quipu.Core.DAL;\n" +
                      "using Quipu.Core.DomainModel;\n\n";

            output += "namespace Quipu.Core.BLL\n" +
                      "{";

            output += $"public class {serviceName} : IModelService<{modelName}>\n" +
                       "{\n";

            output += "\tprivate QContext _context;\n\n";

            output += $"public {serviceName}(QContext context)\n" +
                       "{\n" +
                       "\t_context = context;" +
                       "}\n\n";

            output += $"public async Task<ActionResult<IEnumerable<{modelName}>>> Get() " +
                       "{\n" +
                      $"\treturn await _context.{dbSetName}.ToListAsync();\n" +
                       "}\n\n";

            output += $"public async Task<ActionResult<{modelName}>> Get(int id)\n" +
                       "{\n" +
                      $"\tvar entity = await _context.{dbSetName}.FindAsync(id);\n" +
                       "return entity;\n" +
                       "}\n\n";

            output += $"public async Task<bool> Put({modelName} entity)\n" +
                       "{\n" +
                      $"_context.Entry(entity).State = EntityState.Modified;\n" +
                       "try\n" +
                       "{\n" +
                       "\tawait _context.SaveChangesAsync();\n" +
                       "\treturn true;\n" +
                       "}\n" +
                       "catch (DbUpdateConcurrencyException)\n" +
                       "{\n" +
                       "\tif (!EntityExists(entity.ID))\n" +
                       "{\n" +
                       "\t throw;\n" +
                       "}\n" +
                       "else\n" +
                       "{\n" +
                       "\tthrow;\n" +
                       "}\n" +
                       "}\n" +
                       "}\n\n";

            output += $"public async Task<{modelName}> Post({modelName} entity)\n" +
                       "{\n" +
                       $"\t_context.{dbSetName}.Add(entity);\n" +
                       "\tawait _context.SaveChangesAsync();\n" +
                       "\treturn entity;\n" +
                       "}\n\n";

            output += "public async Task<bool> Delete(int id)\n" +
                      "{\n" +
                      $"\tvar entity = await _context.{dbSetName}.FindAsync(id);\n" +
                      $"\t_context.{dbSetName}.Remove(entity);\n" +
                      "\tawait _context.SaveChangesAsync();\n" +
                      "return true;\n" +
                      "}\n\n";

            output += "private bool EntityExists(int id)\n" +
                      "{\n" +
                      $"\treturn _context.{dbSetName}.Any(x =>x.ID == id);\n" +
                      "}\n" +
                      "}\n" +
                      "}"; 

            return output;
        }

    }
}
