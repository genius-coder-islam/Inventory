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
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateCustomerViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PageResult<CustomerViewModel> GetAll(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public CustomerViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
