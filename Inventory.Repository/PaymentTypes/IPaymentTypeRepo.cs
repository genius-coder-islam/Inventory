using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.PaymentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.PaymentTypes
{
    public interface IPaymentTypeRepo
    {
        PageResult<PaymentTypeViewModel> GetAll(int pageSize, int PageNumber);
        void Add(CreatePaymentTypeViewModel model);
        void Update(PaymentTypeViewModel model);
        void Delete(int id);
        PaymentTypeViewModel GetById(int id);
    }
}
