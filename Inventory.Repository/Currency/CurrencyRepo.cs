using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Currency;
using Inventory.ViewModel.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Currency
{
    public class CurrencyRepo : ICurrencyRepo
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreateCurrencyViewModel vm)
        {
            var model = new CreateCurrencyViewModel().Convert(vm);
            _context.Currencies.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Currencies.Where(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.Currencies.Remove(model);
            }
            _context.SaveChanges();
        }

        public PageResult<CurrencyViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<CurrencyViewModel> vmList = new List<CurrencyViewModel>();

            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);

                var modelList = _context.Currencies.Skip(ExcludeRecords).Take(pageSize).ToList();

                // FIXED: was wrongly using BillTypes (copy-paste mistake from previous repo)
                totalCount = (from c in _context.Currencies
                              select c).ToList().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex) { throw; }

            // FIXED: use constructor instead of object initializer
            var result = new PageResult<CurrencyViewModel>(
                vmList,
                totalCount,
                pageNumber,
                pageSize);

            return result;
        }
        private List<CurrencyViewModel> ConvertModelToViewModelList(List<Inventory.Models.Currency> modelList)
        {
            return modelList.Select(x => new CurrencyViewModel(x)).ToList();
        }

        public CurrencyViewModel GetById(int id)
        {
            var model = _context.Currencies.Where(x => x.Id == id).FirstOrDefault();
            var vm = new CurrencyViewModel(model);
            return vm;
        }

        public void Update(CurrencyViewModel vm)
        {
            var model = _context.Currencies.Where(x => x.Id == vm.Id).FirstOrDefault();
            if (model != null)
            {
                model.Code = vm.Code;
                model.Name = vm.Name;
                model.Description = vm.Description;

            }
            _context.SaveChanges();
        }
    }
}
