using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Currency
{
    public interface ICurrencyRepo
    {
        PageResult<CurrencyViewModel> GetAll(int pageNumber, int pageSize);
        void Add(CreateCurrencyViewModel model);
        void Update(CurrencyViewModel model);
        void Delete(int id);
        CurrencyViewModel GetById(int id);
    }
}
