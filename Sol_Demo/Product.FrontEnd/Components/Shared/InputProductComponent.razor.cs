using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Product.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Components.Shared
{
    public partial class InputProductComponent
    {
        #region Public Property

        [Parameter]
        public ProductModel Product { get; set; }

        [Parameter]
        public EventCallback OnSubmit { get; set; }

        #endregion Public Property
    }
}