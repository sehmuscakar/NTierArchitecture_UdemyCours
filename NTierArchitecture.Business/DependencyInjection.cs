using Microsoft.Extensions.DependencyInjection;

namespace NTierArchitecture.Business
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddBusiness(this IServiceCollection services) //IServiceCollection services bunun sayesinde api katmanında program .cs te bunları tanımlayacaz 
        {
         //   services.AddMediatR

            return services;
        }
    }
}
