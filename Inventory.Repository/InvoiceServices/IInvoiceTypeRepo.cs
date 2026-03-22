using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.InvoiceServices
{
    public interface IInvoiceTypeRepo
    {
        PageResult<InvoiceTypeViewModel> GetAll(int pageSize, int PageNumber);
        void Add(CreateInvoiceTypeViewModel model);
        void Update(InvoiceTypeViewModel model);
        void Delete(int id);
        InvoiceTypeViewModel GetById(int id);
    }
}
