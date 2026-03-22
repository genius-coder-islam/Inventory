using Inventory.Repository.BillTypeService;
using Inventory.ViewModel.Bill;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class BillTypesController : Controller
    {
        private IBillTypeRepo _billTypeRepo;

        public BillTypesController(IBillTypeRepo billTypeRepo)
        {
            _billTypeRepo = billTypeRepo;
        }
        [HttpGet]
        //public Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        //{
        //    var billTypes = _billTypeRepo.GetAll(pageSize, pageNumber);

        //    // Instead of 'return View(billTypes);'
        //    // We manually wrap the ViewResult into a Task to match the method signature
        //    return Task.FromResult<IActionResult>(View(billTypes.Result));
        //}
        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var billTypes = await _billTypeRepo.GetAll(pageSize, pageNumber);
            return View(billTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBillTypeViewModel model)
        {

            if (ModelState.IsValid)
            {
                _billTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _billTypeRepo.GetById(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _billTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
