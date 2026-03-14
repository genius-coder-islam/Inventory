using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int AvailQuantity { get; set; }

        public Status Status { get; set; }

    }
}

namespace Inventory.Models
{
    public enum Status
    {
        Ok, Defective
    }
}