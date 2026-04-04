using Inventory.Repository.Currency;
using Inventory.Repository.Shipment;
using Inventory.ViewModel.Currency;
using Inventory.ViewModel.Shipment;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class CurrenciesController : Controller
    {
        private ICurrencyRepo _currencyRepo;

        public CurrenciesController(ICurrencyRepo currencyRepo)
        {
            _currencyRepo = currencyRepo;
        }
        //[HttpGet]
        //public Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        //{
        //    var billTypes = _currencyRepo.GetAll(pageSize, pageNumber);

        //    // Instead of 'return View(billTypes);'
        //    // We manually wrap the ViewResult into a Task to match the method signature
        //    return Task.FromResult<IActionResult>(View(billTypes.Result));
        //}
        //[HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var currencies = _currencyRepo.GetAll(pageSize, pageNumber);
            return View(currencies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCurrencyViewModel model)
        {

            if (ModelState.IsValid)
            {
                _currencyRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _currencyRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CurrencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                _currencyRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _currencyRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
