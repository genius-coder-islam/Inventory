using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductService
{
    public class ProductRepo : IProductRepo
    {
        private ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PageResult<ProductListViewModel>> GetAll(int pageSize, int PageNumber)
        {

            var products = _context.Products;
            var vm = products.ModelToVM().AsQueryable();
            return await PageResult<ProductListViewModel>.CreateAsync(vm, PageNumber, pageSize);

        }
    }
}
