using Inventory.Repository.InvoiceServices;
using Inventory.Repository.VendorTypeService;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class VendorTypesController : Controller
    {
        private IVendorTypeRepo _vendorTypeRepo;

        public VendorTypesController(IVendorTypeRepo vendorTypeRepo)
        {
            _vendorTypeRepo = vendorTypeRepo;
        }
        //[HttpGet]
        //public Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        //{
        //    var billTypes = _vendorTypeRepo.GetAll(pageSize, pageNumber);

        //    // Instead of 'return View(invoiceTypes);'
        //    // We manually wrap the ViewResult into a Task to match the method signature
        //    return Task.FromResult<IActionResult>(View(invoiceTypes.Result));
        //}
        [HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var vendorTypes = _vendorTypeRepo.GetAll(pageSize, pageNumber);
            return View(vendorTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVendorTypeViewModel model)
        {

            if (ModelState.IsValid)
            {
                _vendorTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _vendorTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(VendorTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _vendorTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _vendorTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
