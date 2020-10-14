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
    public class AddProductRepository : ProductRepositoryAbstract, IAddProductRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public AddProductRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<bool> IAddProductRepository.AddProductAsync(ProductModel productModel)
        {
            try
            {
                return
                    await
                        sqlClientDbProvider
                        ?.DapperBuilder
                        ?.OpenConnection(this.sqlClientDbProvider?.GetConnection())
                        ?.Parameter(async () => await base.SetParameterAsync("Add", productModel))
                        ?.Command(async (dbConnection, dynamicParameter) =>
                        {
                            var data =
                                    await
                                        dbConnection
                                        ?.QueryFirstAsync<MessageResultSet>(sql: "uspSetProducts", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                            return (data.Message.Contains("Add")) ? true : false;
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