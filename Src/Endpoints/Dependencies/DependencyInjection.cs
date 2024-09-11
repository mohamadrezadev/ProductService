using Endpoint.Api.Validators;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Endpoint.Api.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices( this IServiceCollection Services,IConfiguration Configuration )
        {
           
            Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductCreateDtoValidator>());
          
            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Apis services ", Version = "v1" });
        
                // Register examples
                c.ExampleFilters();
            });
            Services.AddSwaggerExamplesFromAssemblyOf<Program>();

            return Services;
        }
    }
}
