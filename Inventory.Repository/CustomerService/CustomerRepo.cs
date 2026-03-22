using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerService
{
    public class ProductRepo : IProductRepo
    {
        private ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PageResult<CustomerListViewModel>> GetAll(int pageSize, int PageNumber)
        {

            var customerList = _context.Customers;
            var vm = customerList.ModelToVM().AsQueryable();
            return await PageResult<CustomerListViewModel>.CreateAsync(vm, PageNumber, pageSize);

        }
    }
}
