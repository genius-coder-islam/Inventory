using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        [Display(Name = "Sales Order")]
        public string Name { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Display(Name = "Sales Type")]
        public int SalesTypeId { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public ICollection<SalesOrderLine> SalesOrderLines { get; set; }
        = new HashSet<SalesOrderLine>();

    }
}
