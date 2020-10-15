using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Product.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.Components.Shared
{
    public partial class InputProductComponent
    {
        #region Public Property

        [Parameter]
        public ProductModel Product { get; set; }

        [Parameter]
        public EventCallback OnSubmit { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        #endregion Public Property

        #region Private Event Handler

        private async Task OnCancel()
        {
            await JSRuntime.InvokeVoidAsync(identifier: "onCancel");
        }

        #endregion Private Event Handler
    }
}