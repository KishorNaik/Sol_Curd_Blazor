using Api.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Api.Repository.Abstract
{
    public abstract class ProductRepositoryAbstract
    {
        protected virtual Task<DynamicParameters> SetParameterAsync(String command, ProductModel productModel = null)
        {
            try
            {
                return Task.Run(() =>
                {
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Command", command, direction: ParameterDirection.Input);
                    dynamicParameter.Add("@ProductIdentity", productModel?.ProductIdentity, direction: ParameterDirection.Input);
                    dynamicParameter.Add("@ProductName", productModel?.ProductName, direction: ParameterDirection.Input);
                    dynamicParameter.Add("@UnitPrice", productModel?.UnitPrice, direction: ParameterDirection.Input);

                    return dynamicParameter;
                });
            }
            catch
            {
                throw;
            }
        }

        protected virtual Task<DynamicParameters> GetParameterAsync(String command, ProductModel productModel = null)
        {
            try
            {
                return Task.Run(() =>
                {
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Command", command, direction: ParameterDirection.Input);

                    return dynamicParameter;
                });
            }
            catch
            {
                throw;
            }
        }
    }
}