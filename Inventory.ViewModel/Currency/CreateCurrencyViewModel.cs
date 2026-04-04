using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Currency
{
    public class CreateCurrencyViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public CreateCurrencyViewModel()
        {
            
        }
        public CreateCurrencyViewModel(Inventory.Models.Currency currency)
        {
            Name = currency.Name;
            Code = currency.Code;
            Description = currency.Description;
        }
        public Inventory.Models.Currency Convert(CreateCurrencyViewModel vm)
        {
            var model = new Inventory.Models.Currency();
            model.Name = vm.Name;
            model.Code = vm.Code;
            model.Description = vm.Description;
            return model;
        }
    }
}
