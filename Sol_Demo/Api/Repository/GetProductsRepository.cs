using Api.Cores.Repositories;
using Api.Models;
using Api.Providers;
using Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Api.Repository
{
    public sealed class GetProductsRepository : ProductRepositoryAbstract, IGetProductsRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public GetProductsRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<IReadOnlyCollection<ProductModel>> IGetProductsRepository.GetProductsAsync()
        {
            try
            {
                return
                    await
                        sqlClientDbProvider
                        ?.DapperBuilder
                        ?.OpenConnection(this.sqlClientDbProvider.GetConnection())
                        ?.Parameter(async () => await base.GetParameterAsync("Get-Products"))
                        ?.Command(async (dbConnection, dynamicParameter) =>
                        {
                            var data =
                                    await
                                        dbConnection
                                        .QueryAsync<ProductModel>(sql: "uspGetProducts", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                            return data?.ToList().AsReadOnly();
                        })
                        ?.ResultAsync<IReadOnlyCollection<ProductModel>>();
            }
            catch
            {
                throw;
            }
        }
    }
}