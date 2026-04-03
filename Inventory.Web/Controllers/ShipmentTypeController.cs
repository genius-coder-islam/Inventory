using Inventory.Repository.ProductTypeService;
using Inventory.Repository.Shipment;
using Inventory.ViewModel.Product;
using Inventory.ViewModel.Shipment;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class ShipmentTypeController : Controller
    {
        private IShipmentTypeRepo _shipmentTypeRepo;

        public ShipmentTypeController(IShipmentTypeRepo shipmentTypeRepo)
        {
            _shipmentTypeRepo = shipmentTypeRepo;
        }
        //[HttpGet]
        //public Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        //{
        //    var billTypes = _shipmentTypeRepo.GetAll(pageSize, pageNumber);

        //    // Instead of 'return View(billTypes);'
        //    // We manually wrap the ViewResult into a Task to match the method signature
        //    return Task.FromResult<IActionResult>(View(billTypes.Result));
        //}
        //[HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var shipmentTypes = _shipmentTypeRepo.GetAll(pageSize, pageNumber);
            return View(shipmentTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateShipmentTypeViewModel model)
        {

            if (ModelState.IsValid)
            {
                _shipmentTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _shipmentTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ShipmentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _shipmentTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _shipmentTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
