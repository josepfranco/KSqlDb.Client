namespace KSqlDb.Client.Extensions
{
    using System;
    using System.Net.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Options;
    using Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddKsqlDbClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KsqlConnectionOptions>(configuration.GetSection("KsqlDb"));

            services.AddHttpClient<IKsqlDbDescribeService, DescribeService>(ConfigureClientWithAppsettings());
            services.AddHttpClient<IKsqlDbExecuteService, ExecuteService>(ConfigureClientWithAppsettings());
            services.AddHttpClient<IKsqlDbExplainService, ExplainService>(ConfigureClientWithAppsettings());
            services.AddHttpClient<IKsqlDbTablesService, TablesService>(ConfigureClientWithAppsettings());

            services.AddTransient<IKsqlDbClient, KsqlDbClient>(sp =>
            {
                var describeService = sp.GetRequiredService<IKsqlDbDescribeService>();
                var explainService  = sp.GetRequiredService<IKsqlDbExplainService>();
                var executeService  = sp.GetRequiredService<IKsqlDbExecuteService>();
                var tablesService  = sp.GetRequiredService<IKsqlDbTablesService>();

                return new KsqlDbClient(describeService, explainService, executeService, tablesService);
            });

            return services;
        }

        private static Action<IServiceProvider, HttpClient> ConfigureClientWithAppsettings() =>
            (sp, c) =>
            {
                var options = sp.GetRequiredService<IOptions<KsqlConnectionOptions>>();
                c.BaseAddress = new Uri($"{options.Value.Host}:{options.Value.Port}");
            };
    }
}
