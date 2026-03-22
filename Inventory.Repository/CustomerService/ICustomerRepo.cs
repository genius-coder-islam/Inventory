using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerService
{
    public interface IProductRepo
    {

        Task<PageResult<CustomerListViewModel>> GetAll(int pageSize, int PageNumber);

    }
}
