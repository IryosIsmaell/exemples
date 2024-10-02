using Ark.CrossCutting.AdapterProviders;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Ark.CrossCutting.Extensions
{
    /// <summary>
    /// Contains necessary <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services for unobtrusive client side validation support for ASP.NET Core Custom Validation.
        /// </summary>
        /// <param name="services">Extend the type <see cref="IServiceCollection"/>.</param>
        public static void AddAspNetCoreCustomValidation(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, ElyonAttributeAdapterProvider>();
        }
    }
}
