using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.InvoiceServices
{
    public class InvoiceTypeRepo : IInvoiceTypeRepo
    {
        private readonly ApplicationDbContext _context;

        public InvoiceTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreateInvoiceTypeViewModel vm)
        {
            var invoiceType = new CreateInvoiceTypeViewModel().Convert(vm);
            _context.InvoiceTypes.Add(invoiceType);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.InvoiceTypes.Where(x => x.InvoiceTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.InvoiceTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public PageResult<InvoiceTypeViewModel> GetAll(int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<InvoiceTypeViewModel> vmList = new List<InvoiceTypeViewModel>();

            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);

                var modelList = _context.InvoiceTypes
                    .Skip(ExcludeRecords)
                    .Take(pageSize)
                    .ToList();

                // FIXED: was wrongly using BillTypes (copy-paste mistake from previous repo)
                totalCount = _context.InvoiceTypes.ToList().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex) { throw; }

            // FIXED: use constructor instead of object initializer
            var result = new PageResult<InvoiceTypeViewModel>(
                vmList,
                totalCount,
                pageNumber,
                pageSize);

            return result;
        }
        private List<InvoiceTypeViewModel> ConvertModelToViewModelList(List<InvoiceType> modelList)
        {
            return modelList.Select(x => new InvoiceTypeViewModel(x)).ToList();
        }

        public InvoiceTypeViewModel GetById(int id)
        {
            var model = _context.InvoiceTypes.Where(x => x.InvoiceTypeId == id).FirstOrDefault();
            var vm = new InvoiceTypeViewModel(model);
            return vm;
        }

        public void Update(InvoiceTypeViewModel vm)
        {
            var model = _context.InvoiceTypes.Where(x => x.InvoiceTypeId == vm.InvoiceTypeId).FirstOrDefault();
            if (model != null)
            {

                model.InvoiceTypeName = vm.InvoiceTypeName;
                model.Description = vm.Description;

            }
            _context.SaveChanges();
        }
    }
}
