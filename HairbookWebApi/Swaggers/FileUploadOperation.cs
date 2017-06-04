using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;

namespace HairbookWebApi.Swaggers
{
    public class FileUploadOperation : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.OperationId == "ApiV{versionPostUploadsUploadPost" ||
                operation.OperationId == "ApiV{versionMemoUploadsUploadPost")
            {
                var otherParams = operation.Parameters.Where(x => x.In != "modelbinding").ToList();

                operation.Parameters.Clear();
                foreach (var p in otherParams)
                {
                    operation.Parameters.Add(p);
                }

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "uploadedFile",
                    In = "formData",
                    Description = "Upload File",
                    Required = true,
                    Type = "file"
                });
                operation.Consumes.Add("multipart/form-data");
            }
        }
    }
}
