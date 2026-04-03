using Inventory.Repository.PaymentTypes;
using Inventory.Repository.Purchase;
using Inventory.ViewModel.PaymentType;
using Inventory.ViewModel.Purchase;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class PurchaseTypesController : Controller
    {
        private IPurchaseTypeRepo _purchaseTypeRepo;

        public PurchaseTypesController(IPurchaseTypeRepo purchaseTypeRepo)
        {
            _purchaseTypeRepo = purchaseTypeRepo;
        }
        //[HttpGet]
        //public Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        //{
        //    var billTypes = _purchaseTypeRepo.GetAll(pageSize, pageNumber);

        //    // Instead of 'return View(billTypes);'
        //    // We manually wrap the ViewResult into a Task to match the method signature
        //    return Task.FromResult<IActionResult>(View(billTypes.Result));
        //}
        //[HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var purchaseTypes = _purchaseTypeRepo.GetAll(pageSize, pageNumber);
            return View(purchaseTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePurchaseTypeViewModel model)
        {

            if (ModelState.IsValid)
            {
                _purchaseTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _purchaseTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(PurchaseTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _purchaseTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _purchaseTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
