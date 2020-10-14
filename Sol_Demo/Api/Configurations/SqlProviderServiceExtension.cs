using Api.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configurations
{
    public static class SqlProviderServiceExtension
    {
        public static void AddSqlProvider(this IServiceCollection services)
        {
            services.AddTransient<ISqlClientDbProvider, SqlClientDbProvider>();
        }
    }
}