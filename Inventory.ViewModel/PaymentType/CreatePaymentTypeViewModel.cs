using Inventory.Models;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.PaymentType
{
    public class CreatePaymentTypeViewModel
    {
        public string PaymentTypeName { get; set; }
        public string Description { get; set; }
        public Inventory.Models.PaymentType Convert(CreatePaymentTypeViewModel vm)
        {
            Inventory.Models.PaymentType model = new Inventory.Models.PaymentType();
            model.PaymentTypeName = vm.PaymentTypeName;
            model.Description = vm.Description;
            return model;
        }
    }
}
