using CD.Web.Repositories;
using CD.Web.Services;

namespace CD.Web.Context
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<ProdutoService>();
            services.AddScoped<VendaService>();
            services.AddScoped<ClienteService>();

            return services;
        }
    }
}
