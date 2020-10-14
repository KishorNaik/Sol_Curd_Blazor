using Microsoft.AspNetCore.Components;
using Product.FrontEnd.Models;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.Components
{
    public partial class DeleteProductComponent
    {
        #region Public Property

        [Parameter]
        public ProductModel SelectedProduct { get; set; }

        [Inject]
        public IProductService ProductServiceObj { get; set; }

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        #endregion Public Property

        #region Private Property

        private bool IsDisplay { get; set; }

        #endregion Private Property

        #region Private Method

        public async Task<bool> DeleteProductApiCall()
        {
            return await this.ProductServiceObj?.DeleteProductApiAsync(this.SelectedProduct);
        }

        #endregion Private Method

        #region Private Event Handler

        private void OnCancelDeleteDialog()
        {
            IsDisplay = false;
            base.StateHasChanged();
            this.RefreshEvent.InvokeAsync("Refresh Event");
        }

        private async Task OnYes()
        {
            var apiResponse = await this.DeleteProductApiCall();

            if (apiResponse == true)
            {
                this.IsDisplay = false;
                base.StateHasChanged();
                await this.RefreshEvent.InvokeAsync("Refresh Event");
            }
        }

        #endregion Private Event Handler

        #region Public Method

        public void ShowDeleteDialog()
        {
            IsDisplay = true;
            base.StateHasChanged();
        }

        #endregion Public Method

        #region Protected Method

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                base.StateHasChanged();
            }
        }

        #endregion Protected Method
    }
}