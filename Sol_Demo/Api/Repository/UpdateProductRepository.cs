using Api.Cores.Repositories;
using Api.Models;
using Api.Providers;
using Api.Repository.Abstract;
using Api.Repository.ResultSet;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public sealed class UpdateProductRepository : ProductRepositoryAbstract, IUpdateProductRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public UpdateProductRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<bool> IUpdateProductRepository.UpdateProductAsync(ProductModel productModel)
        {
            try
            {
                return
                    await
                        sqlClientDbProvider
                        ?.DapperBuilder
                        ?.OpenConnection(this.sqlClientDbProvider.GetConnection())
                        ?.Parameter(async () => await base.SetParameterAsync("Update", productModel))
                        ?.Command(async (dbConnection, dynamicParameter) =>
                        {
                            var data =
                                    await
                                        dbConnection
                                        .QueryFirstAsync<MessageResultSet>(sql: "uspSetProducts", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                            return (data.Message.Contains("Update")) ? true : false;
                        })
                        ?.ResultAsync<bool>();
            }
            catch
            {
                throw;
            }
        }
    }
}