using Microsoft.AspNetCore.Components;
using Product.FrontEnd.Models;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.Components
{
    public partial class ProductGridComponent
    {
        #region Public  Property

        [Inject]
        public IProductService ProductServiceObj { get; set; }

        #endregion Public  Property

        #region Private Property

        private bool IsLoad { get; set; }

        private List<ProductModel> ListProducts { get; set; }

        private AddProductComponent AddProductComp { get; set; }

        private EditProductComponent EditProductComp { get; set; }

        private DeleteProductComponent DeleteProductComp { get; set; }

        private ProductModel SelectedProduct { get; set; }

        private String ErrorMessage { get; set; }

        #endregion Private Property

        #region Private Method

        private async Task GetProductDataAsync()
        {
            try
            {
                ListProducts = (await ProductServiceObj?.GetProductsAsync()).ToList();

                if (ListProducts == null || ListProducts?.Count == 0)
                {
                    ErrorMessage = "No Record Found";
                }
            }
            catch
            {
                throw;
            }
        }

        private async Task RefreshState()
        {
            await GetProductDataAsync();

            base.StateHasChanged();
        }

        private ProductModel FilterProduct(Guid guid)
        {
            return ListProducts
                                ?.FirstOrDefault((productModel) => productModel.ProductIdentity == guid);
        }

        #endregion Private Method

        #region Private Event Handler

        private void OnAdd()
        {
            AddProductComp.ShowAddDialog();
        }

        private void OnEdit(Guid guid)
        {
            this.SelectedProduct = this.FilterProduct(guid);
            base.StateHasChanged();

            EditProductComp.ShowEditDialog();
        }

        private void OnDelete(Guid guid)
        {
            this.SelectedProduct = this.FilterProduct(guid);
            base.StateHasChanged();

            DeleteProductComp.ShowDeleteDialog();
        }

        #endregion Private Event Handler

        #region Protected Event

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Delay(1000);

                await this.GetProductDataAsync();

                IsLoad = true;

                base.StateHasChanged();
            }
        }

        #endregion Protected Event
    }
}