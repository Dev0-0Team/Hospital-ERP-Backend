using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hospital_ERP_Backend.API.Filters
{
    public class DefaultResponsesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.TryAdd("200", new OpenApiResponse { Description = "OK" });
            operation.Responses.TryAdd("400", new OpenApiResponse { Description = "Bad Request" });
            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });
            operation.Responses.TryAdd("404", new OpenApiResponse { Description = "Not Found" });
            operation.Responses.TryAdd("409", new OpenApiResponse { Description = "Conflict" });
            operation.Responses.TryAdd("429", new OpenApiResponse { Description = "Too Many Requests" });
            operation.Responses.TryAdd("500", new OpenApiResponse { Description = "Server Error" });
            if (context.ApiDescription.HttpMethod == "POST")
            {
                operation.Responses.TryAdd("201", new OpenApiResponse { Description = "Created" });
            }
        }
    }
}
