using Quipu.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quipu.CodeGen
{
    public class ModelControllerBuilder
    {
        private string _controllerDirectoryPath;
        private Type[] _domainModelTypes;

        public ModelControllerBuilder(string controllerDirectoryPath,
                                   Type[] domainModelTypes)
        {
            _controllerDirectoryPath = controllerDirectoryPath;
            _domainModelTypes = domainModelTypes;
        }

        public async void Build()
        {
            foreach (Type modelType in _domainModelTypes)
            {
                // Only build the service if the service doesn't already exist. 
                // We only want to help with initialization of a new domain model, 
                // we don't want to impede custom requirements for model services.
                if (!ControllerAlreadyExists(modelType))
                {
                    string fileContents = BuildFileContents(modelType);
                    string filePath = GetFilePath(modelType);
                    await File.WriteAllTextAsync(filePath, fileContents);
                }
            }
        }

        private bool ControllerAlreadyExists(Type modelType)
        {
            string path = GetFilePath(modelType);
            return File.Exists(path);
        }

        private string GetFilePath(Type modelType)
        {
            string modelName = modelType.Name + "s";
            if(modelType == typeof(TaskStatusCategory))
            {
                modelName = "TaskStatusCategories";
            }
            else if(modelType == typeof(Settings))
            {
                modelName = "Settings";
            }
            return _controllerDirectoryPath + "/" + modelName + "Controller.cs";
        }

        private static string BuildFileContents(Type modelType)
        {
            string output = "";
            string modelName = modelType.Name;
            string modelControllerTitle = modelType.Name + "s";
            string className = modelControllerTitle + "Controller";

            output += "using System.Collections.Generic;\n" +
                      "using System.Threading.Tasks;\n" +
                      "using Microsoft.AspNetCore.Mvc;\n" +
                      "using Quipu.Core.BLL;\n" +
                      "using Quipu.Core.DomainModel;\n" +
                      "\n" +
                      "namespace Quipu.Core.Controllers\n" +
                      "{\n" +
                      "    [Route(\"api/[controller]\")]\n" +
                      "    [ApiController]\n" +
                     $"    public class {className} : ControllerBase\n" +
                      "    {\n" +
                     $"        private readonly IModelService<{modelName}> _modelService;\n" +
                      "\n" +
                     $"        public {className}(IModelService<{modelName}> service)\n" +
                      "        {\n" +
                      "            _modelService = service;\n" +
                      "        }\n" +
                      "\n" +
                     $"        // GET: api/{modelControllerTitle}\n" +
                      "        [HttpGet]\n" +
                     $"        public async Task<ActionResult<IEnumerable<{modelName}>>> Get{modelControllerTitle}()\n" +
                      "        {\n" +
                      "            return await _modelService.Get();\n" +
                      "        }\n" +
                      "\n" +
                     $"        // GET: api/{modelControllerTitle}/5\n" +
                      "        [HttpGet(\"{id}\")]\n" +
                     $"        public async Task<ActionResult<{modelName}>> Get{modelName}(int id)\n" +
                      "        {\n" +
                      "            var entity = await _modelService.Get(id);\n" +
                      "\n" +
                      "            if (entity == null)\n" +
                      "            {\n" +
                      "                return NotFound();\n" +
                      "            }\n" +
                      "\n" +
                      "            return entity;\n" +
                      "        }\n" +
                      "\n" +
                     $"        // PUT: api/{modelControllerTitle}/5\n" +
                      "        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754\n" +
                      "        [HttpPut(\"{id}\")]\n" +
                     $"        public async Task<IActionResult> Put{modelName}(int id, {modelName} entity)\n" +
                      "        {\n" +
                      "            if (id != entity.ID)\n" +
                      "            {\n" +
                      "                return BadRequest();\n" +
                      "            }\n" +
                      "\n" +
                      "            if (await _modelService.Put(entity))\n" +
                      "            {\n" +
                      "                return NoContent();\n" +
                      "            }\n" +
                      "            else\n" +
                      "            {\n" +
                      "                return BadRequest();\n" +
                      "            }\n" +
                      "        }\n" +
                      "\n" +
                     $"        // POST: api/{modelControllerTitle}\n" +
                      "        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754\n" +
                      "        [HttpPost]\n" +
                     $"        public async Task<ActionResult<{modelName}>> Post{modelName}({modelName} entity)\n" +
                      "        {\n" +
                      "            var postedEntity = await _modelService.Post(entity);\n" +
                      "            if (postedEntity != null)\n" +
                      "            {\n" +
                     $"                return CreatedAtAction(\"Get{modelName}\", new {{ id = postedEntity.ID }}, postedEntity);\n" +
                      "            }\n" +
                      "\n" +
                      "            return BadRequest();\n" +
                      "        }\n" +
                      "\n" +
                     $"        // DELETE: api/{modelControllerTitle}/5\n" +
                      "        [HttpDelete(\"{id}\")]\n" +
                     $"        public async Task<IActionResult> Delete{modelName}(int id)\n" +
                      "        {\n" +
                      "            var entity = await _modelService.Get(id);\n" +
                      "            if (entity == null)\n" +
                      "            {\n" +
                      "                return NotFound();\n" +
                      "            }\n" +
                      "\n" +
                      "            if (await _modelService.Delete(id))\n" +
                      "            {\n" +
                      "                return NoContent();\n" +
                      "            }\n" +
                      "\n" +
                      "            return BadRequest();\n" +
                      "        }\n" +
                      "    }\n" +
                      "}";


            return output;
        }
    }
}
