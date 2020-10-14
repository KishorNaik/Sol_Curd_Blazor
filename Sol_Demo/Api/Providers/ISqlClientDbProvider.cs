using DapperFluent.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Providers
{
    public interface ISqlClientDbProvider : IDbProviders<SqlConnection>
    {
    }
}