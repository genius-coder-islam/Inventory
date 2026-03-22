using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.SalesTypeService
{
    public interface ISalesTypeService
    {
        PageResult<SalesTypeListViewModel> GetAll(int pageSize, int PageNumber);
        void Add(CreateSalesTypeViewModel model);
        void Update(SalesTypeViewModel model);
        void Delete(int id);
        SalesTypeViewModel GetById(int id);
    }
}
