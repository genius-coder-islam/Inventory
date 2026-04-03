using Inventory.Repository.BillTypeService;
using Inventory.Repository.InvoiceServices;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class InvoiceTypesController : Controller
    {
        private IInvoiceTypeRepo _invoiceTypeRepo;

        public InvoiceTypesController(IInvoiceTypeRepo InvoiceTypeRepo)
        {
            _invoiceTypeRepo = InvoiceTypeRepo;
        }
        [HttpGet]
        //public Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        //{
        //    var billTypes = _invoiceTypeRepo.GetAll(pageSize, pageNumber);

        //    // Instead of 'return View(invoiceTypes);'
        //    // We manually wrap the ViewResult into a Task to match the method signature
        //    return Task.FromResult<IActionResult>(View(invoiceTypes.Result));
        //}
        //[HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var invoiceTypes = _invoiceTypeRepo.GetAll(pageSize, pageNumber);
            return View(invoiceTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateInvoiceTypeViewModel model)
        {

            if (ModelState.IsValid)
            {
                _invoiceTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _invoiceTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(InvoiceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _invoiceTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _invoiceTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
