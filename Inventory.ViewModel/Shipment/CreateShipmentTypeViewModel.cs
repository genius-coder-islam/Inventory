using Inventory.Models;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Shipment
{
    public class CreateShipmentTypeViewModel
    {
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
        public ShipmentType Convert(CreateShipmentTypeViewModel vm)
        {
            ShipmentType model = new ShipmentType();
            model.ShipmentTypeName = vm.ShipmentTypeName;
            model.Description = vm.Description;
            return model;
        }
    }
}
