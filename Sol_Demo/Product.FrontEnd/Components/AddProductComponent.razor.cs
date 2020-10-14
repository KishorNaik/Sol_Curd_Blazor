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
    public partial class AddProductComponent
    {
        #region Constructor

        public AddProductComponent()
        {
            Product = new ProductModel();
        }

        #endregion Constructor

        #region Public Property

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        [Inject]
        public IProductService ProductServiceObj { get; set; }

        #endregion Public Property

        #region Private Property

        private bool IsDisplay { get; set; }

        private String ErrorMessage { get; set; }

        private ProductModel Product { get; set; }

        #endregion Private Property

        #region Private Method

        private void CancelAddDialog()
        {
            IsDisplay = false;
            Product = null;
            base.StateHasChanged();
            this.RefreshEvent.InvokeAsync("Refresh Event");
        }

        private async Task<bool> AddProductApiCall()
        {
            return await ProductServiceObj.AddProductApiAsync(this.Product);
        }

        #endregion Private Method

        #region Private Event Handler

        public async Task OnSubmit(EditContext editContext)
        {
            var flag = editContext?.Validate();
            if (flag == false) return;

            var apiResponse = await this.AddProductApiCall();

            if (apiResponse == true)
            {
                IsDisplay = false;
                Product = null;
                base.StateHasChanged();
                await this.RefreshEvent.InvokeAsync("Refresh Event");
            }
            else
            {
                ErrorMessage = $"{Product.ProductName} product already exists in database";
                base.StateHasChanged();
            }
        }

        #endregion Private Event Handler

        #region Public Method

        public void ShowAddDialog()
        {
            IsDisplay = true;
            Product = Product ?? new ProductModel();
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