using Inventory.Models;
using Inventory.ViewModel.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Product
{
    public class CreateProductTypeViewModel
    {
        public string ProductTypeName { get; set; }
        public string Description { get; set; }
        public ProductType Convert(CreateProductTypeViewModel vm)
        {
            ProductType model = new ProductType();
            model.ProductTypeName = vm.ProductTypeName;
            model.Description = vm.Description;
            return model;
        }
    }
}
