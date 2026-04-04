using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Currency
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public CurrencyViewModel()
        {
            
        }
        public CurrencyViewModel(Inventory.Models.Currency model)
        {
            Id = model.Id;
            Name = model.Name;
            Code = model.Code;
            Description = model.Description;
        }
    }
}
