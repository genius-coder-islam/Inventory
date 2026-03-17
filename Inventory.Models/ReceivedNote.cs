using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ReceivedNote
    {
        public int Id { get; set; }
        public string ShipmentName { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTimeOffset GRNDate { get; set; }
        public string VendorNumber { get; set; }
        public string VendorInvoiceNumber { get; set; }
        public int WarehouseId { get; set; }
        public bool IsFullReceive { get; set; } = true;

    }
}
