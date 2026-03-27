using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Product;
using Inventory.ViewModel.Purchase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductTypeService
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private ApplicationDbContext _context;

        public ProductTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateProductTypeViewModel vm)
        {
            var model = new CreateProductTypeViewModel().Convert(vm);
            _context.ProductTypes.Add(model);
            _context.SaveChanges(); ;
        }

        public void Delete(int id)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.ProductTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public PageResult<ProductTypeViewModel> GetAll(int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<ProductTypeViewModel> vmList = new List<ProductTypeViewModel>();

            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);

                var modelList = _context.ProductTypes
                    .Skip(ExcludeRecords)
                    .Take(pageSize)
                    .ToList();

                // FIXED: was wrongly using BillTypes (copy-paste mistake from previous repo)
                totalCount = _context.ProductTypes.Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex) { throw; }

            // FIXED: use constructor instead of object initializer
            var result = new PageResult<ProductTypeViewModel>(
                vmList,
                totalCount,
                pageNumber,
                pageSize);

            return result;
        }
        private List<ProductTypeViewModel> ConvertModelToViewModelList(List<ProductType> modelList)
        {
            return modelList.Select(x => new ProductTypeViewModel(x)).ToList();
        }

        public ProductTypeViewModel GetById(int id)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            var vm = new ProductTypeViewModel(model);
            return vm;
        }

        public void Update(ProductTypeViewModel vm)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == vm.ProductTypeId).FirstOrDefault();
            if (model != null)
            {
                model.ProductTypeName = vm.ProductTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
