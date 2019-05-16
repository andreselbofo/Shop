using System;
using System.Collections.Generic;
using System.Text;
using Shop.Common.Models;

namespace Shop.UIForms.ViewModels
{
    public class EditProductViewModel
    {
        public Product product { get; set; }
        
        public EditProductViewModel(Product product)
        {
            this.product = product;
        }
    }
}
