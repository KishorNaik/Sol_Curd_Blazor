using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Product.FrontEnd.Models;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.Components
{
    public partial class EditProductComponent
    {
        #region Public Property

        [Parameter]
        public ProductModel SelectedProduct { get; set; }

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        [Inject]
        public IProductService ProductServiceObj { get; set; }

        #endregion Public Property

        #region Private Property

        private bool IsDisplay { get; set; }

        private String ErrorMessage { get; set; }

        #endregion Private Property

        #region Private Method

        private void CancelEditDialog()
        {
            IsDisplay = false;
            base.StateHasChanged();
            RefreshEvent.InvokeAsync("Refresh");
        }

        private async Task<bool> EditUpdateApiCall()
        {
            return await this.ProductServiceObj?.UpdateProductApiAsync(this.SelectedProduct);
        }

        #endregion Private Method

        #region Private Event Handler

        private async Task OnSubmit(EditContext editContext)
        {
            var flag = editContext?.Validate();
            if (flag == false) return;

            var apiResponse = await this.EditUpdateApiCall();

            if (apiResponse == true)
            {
                IsDisplay = false;
                base.StateHasChanged();
                await this.RefreshEvent.InvokeAsync("Refresh Event");
            }
            else
            {
                ErrorMessage = $"{SelectedProduct.ProductName} product already exists in database";
                base.StateHasChanged();
            }
        }

        #endregion Private Event Handler

        #region Public Method

        public void ShowEditDialog()
        {
            IsDisplay = true;
            base.StateHasChanged();
        }

        #endregion Public Method

        #region Protected Event

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                base.StateHasChanged();
            }
        }

        #endregion Protected Event
    }
}