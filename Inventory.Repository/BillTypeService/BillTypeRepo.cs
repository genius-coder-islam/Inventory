using Inventory.Repository;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Vendor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private readonly ApplicationDbContext _context;

        public BillTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PageResult<BillTypeListViewModel>> GetAll(int pageSize, int PageNumber)
        {
            var billTypes = _context.BillTypes.ToList();
            var vm = billTypes.ModelToVM().AsQueryable();
            return await PageResult<BillTypeListViewModel>.CreateAsync(vm, PageNumber, pageSize);
        }
        public void Add(CreateBillTypeViewModel vm)
        {
            var model = new CreateBillTypeViewModel().Convert(vm);
            _context.BillTypes.Add(model);
            _context.SaveChanges();
        }

        public void Update(BillTypeViewModel vm)
        {
            var model =_context.BillTypes.Where(x => x.BillTypeId == vm.BillTypeId).FirstOrDefault();
            if (model != null)
            {

                model.BillTypeName = vm.BillTypeName;
                model.Description = vm.Description;

            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.BillTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public BillTypeViewModel GetById(int id)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId  == id).FirstOrDefault();
            var vm = new BillTypeViewModel(model);
            return vm;
            
        }
    }
}
