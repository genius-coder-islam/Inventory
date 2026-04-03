using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.ViewModel.Mapping;
using Inventory.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inventory.Repository.CustomerTypeService
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private ApplicationDbContext _context;

        public CustomerTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateCustomerTypeViewModel vm)
        {
            var model = new CreateCustomerTypeViewModel().Convert(vm);
            _context.CustomerTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model =_context.CustomerTypes.Find(id);
            if (model != null)
            {
                _context.CustomerTypes.Remove(model);
                _context.SaveChanges();
            }
        }

        public PageResult<CustomerTypeListViewModel> GetAll(int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<CustomerTypeListViewModel> vmList = new List<CustomerTypeListViewModel>();

            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);

                var modelList = _context.CustomerTypes
                    .Skip(ExcludeRecords)
                    .Take(pageSize)
                    .ToList();

                // FIXED: was wrongly using BillTypes (copy-paste mistake from previous repo)
                totalCount = _context.CustomerTypes.ToList().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex) { throw; }

            // FIXED: use constructor instead of object initializer
            var result = new PageResult<CustomerTypeListViewModel>(
                vmList,
                totalCount,
                pageNumber,
                pageSize);

            return result;
        }
        private List<CustomerTypeListViewModel> ConvertModelToViewModelList(List<CustomerType> modelList)
        {
            List<CustomerTypeListViewModel> vmList = new List<CustomerTypeListViewModel>();

            foreach (var item in modelList)
            {
                vmList.Add(new CustomerTypeListViewModel()
                {
                    CustomerTypeId = item.CustomerTypeId,
                    CustomerTypeName = item.CustomerTypeName,
                    Description = item.Description
                });
            }

            return vmList;
        }

        public CustomerTypeViewModel GetById(int id)
        {
            var model = _context.CustomerTypes.Find(id);
            var vm = new CustomerTypeViewModel(model);
            return vm;
        }

        public void Update(CustomerTypeViewModel vm)
        {
            var model = _context.CustomerTypes.Where(x => x.CustomerTypeId == vm.CustomerTypeId).FirstOrDefault();
            if (model != null)
            {
                model.Description = vm.Description;
                model.CustomerTypeName = vm.CustomerTypeName;
            }
            _context.SaveChanges();
        }

        public IEnumerable<CustomerTypeListViewModel> GetALLWithoutPaging()
        {
            var modelList =  _context.CustomerTypes.ToList();
            var viewModelList = ConvertModelToViewModelList(modelList);
            return viewModelList;
        }

        public PageResult<CustomerTypeListViewModel> Search(string searching, int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<CustomerTypeListViewModel> vmList = new List<CustomerTypeListViewModel>();

            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);

                var modelList = _context.CustomerTypes.Where(x => x.CustomerTypeName.Contains(searching))
                    .Skip(ExcludeRecords)
                    .Take(pageSize)
                    .ToList();

                // FIXED: was wrongly using BillTypes (copy-paste mistake from previous repo)
                totalCount = _context.CustomerTypes.Where(x => x.CustomerTypeName.Contains(searching)).ToList().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex) { throw; }

            // FIXED: use constructor instead of object initializer
            var result = new PageResult<CustomerTypeListViewModel>(
                vmList,
                totalCount,
                pageNumber,
                pageSize);

            return result;
        }
    }
}
