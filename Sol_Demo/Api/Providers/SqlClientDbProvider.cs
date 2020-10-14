using DapperFluent.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Providers
{
    public sealed class SqlClientDbProvider : ISqlClientDbProvider
    {
        private readonly IDapperBuilder dapperBuilder = null;
        private readonly IConfiguration configuration = null;

        public SqlClientDbProvider(IDapperBuilder dapperBuilder, IConfiguration configuration)
        {
            this.dapperBuilder = dapperBuilder;
            this.configuration = configuration;
        }

        IDapperBuilder IDbProviders<SqlConnection>.DapperBuilder => dapperBuilder;

        SqlConnection IDbProviders<SqlConnection>.GetConnection()
        {
            return new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
    }
}