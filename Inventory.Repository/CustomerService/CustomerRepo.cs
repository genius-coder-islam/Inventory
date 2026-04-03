using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Shipment;
using Microsoft.EntityFrameworkCore;
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

        public void Add(CreateCustomerViewModel vm)
        {
            var model = new CreateCustomerViewModel().Convert(vm);
            _context.Customers.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            if (model != null)
            {
                _context.Customers.Remove(model);
            }
            _context.SaveChanges();
        }

        public PageResult<CustomerViewModel> GetAll(int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<CustomerViewModel> vmList = new List<CustomerViewModel>();

            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);

                var modelList = (from c in _context.Customers
                                 join ct in _context.CustomerTypes
                                 on c.CustomerTypeId equals ct.CustomerTypeId
                                 select c).Skip(ExcludeRecords).Take(pageSize).ToList();

                // FIXED: was wrongly using BillTypes (copy-paste mistake from previous repo)
                totalCount = (from c in _context.Customers
                              select c).ToList().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex) { throw; }

            // FIXED: use constructor instead of object initializer
            var result = new PageResult<CustomerViewModel>(
                vmList,
                totalCount,
                pageNumber,
                pageSize);

            return result;
        }
        private List<CustomerViewModel> ConvertModelToViewModelList(List<Customer> modelList)
        {
            return modelList.Select(x => new CustomerViewModel(x)).ToList();
        }

        public CustomerViewModel GetById(int id)
        {
            var model = _context.Customers.Include(x => x.CustomerType).Where(x => x.CustomerId == id).FirstOrDefault();
            var vm = new CustomerViewModel(model);
            return vm;
        }

        public void Update(CustomerViewModel vm)
        {
            var model = _context.Customers.Where(x => x.CustomerId == vm.CustomerId).FirstOrDefault();
            if (model != null)
            {
                model.CustomerId = vm.CustomerId;
                model.CustomerName = vm.CustomerName;
                model.CustomerTypeId = vm.CustomerTypeId;
                model.Address = vm.Address;
                model.City = vm.City;
                model.State = vm.State;
                model.ZioCode = vm.ZioCode;
                model.Phone = vm.Phone;
                model.Email = vm.Email;
                model.ContactPerson = vm.ContactPerson;
            }
            _context.SaveChanges();
        }
    }
}
