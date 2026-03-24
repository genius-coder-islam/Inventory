using Inventory.Repository.Paging;
using Inventory.ViewModel.PaymentType;
using Inventory.ViewModel.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Purchase
{
    public interface IPurchaseTypeRepo
    {
        PageResult<PurchaseTypeViewModel> GetAll(int pageSize, int PageNumber);
        void Add(CreatePurchaseTypeViewModel model);
        void Update(PurchaseTypeViewModel model);
        void Delete(int id);
        PurchaseTypeViewModel GetById(int id);
    }
}
