using Blazored.Modal;
using Microsoft.Extensions.DependencyInjection;

namespace Components
{
    public static class Registrator
    {
        public static IServiceCollection RegisterTailwindComponents(this IServiceCollection services)
        {
            return services.AddBlazoredModal();
        }
    }
}
