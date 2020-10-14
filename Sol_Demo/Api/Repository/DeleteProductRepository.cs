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
using Api.Repository.ResultSet;

namespace Api.Repository
{
    public sealed class DeleteProductRepository : ProductRepositoryAbstract, IDeleteProductRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public DeleteProductRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<bool> IDeleteProductRepository.DeleteProductAsync(ProductModel productModel)
        {
            try
            {
                return
                     await
                        sqlClientDbProvider
                        ?.DapperBuilder
                        ?.OpenConnection(this.sqlClientDbProvider.GetConnection())
                        ?.Parameter(async () => await base.SetParameterAsync("Delete", productModel))
                        ?.Command(async (dbConnection, dynamicParameter) =>
                        {
                            var data =
                                    await
                                        dbConnection
                                        ?.ExecuteAsync(sql: "uspSetProducts", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                            return (data >= 1) ? true : false;
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