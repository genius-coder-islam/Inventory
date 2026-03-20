using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillTypeService
{
    public interface IBillTypeRepo
    {

        Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int PageNumber);

    }
}
