using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
using Inventory.ViewModel.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductTypeService
{
    public interface IProductTypeRepo
    {

        PageResult<ProductTypeViewModel> GetAll(int pageSize, int PageNumber);
        void Add(CreateProductTypeViewModel model);
        void Update(ProductTypeViewModel model);
        void Delete(int id);
        ProductTypeViewModel GetById(int id);

    }
}
