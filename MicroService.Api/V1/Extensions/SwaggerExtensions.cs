using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    static internal class SwaggerExtensions
    {
        static internal void AddSwaggerDefinition(this IServiceCollection services, Assembly assembly)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Micro Service API",
                    Version = "v1",
                });

                options.IncludeXmlComments(() =>
                {
                    var embeddedResource = (
                        from resourceName in assembly.GetManifestResourceNames()
                        where resourceName.Contains("MicroService.Api.xml", System.StringComparison.InvariantCultureIgnoreCase)
                        select resourceName).FirstOrDefault();

                    using var stream = assembly.GetManifestResourceStream(embeddedResource);
                    return new System.Xml.XPath.XPathDocument(stream ?? System.IO.Stream.Null);
                }, includeControllerXmlComments: true);
            });
        }
    }
}
