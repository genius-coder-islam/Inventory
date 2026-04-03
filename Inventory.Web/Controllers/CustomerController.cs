using Inventory.Repository.CustomerService;
using Inventory.Repository.CustomerTypeService;
using Inventory.Repository.Shipment;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Shipment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepo _customerRepo;
        private ICustomerTypeRepo _customerTypeRepo;

        public CustomerController(ICustomerRepo customerRepo, 
            ICustomerTypeRepo customerTypeRepo)
        {
            _customerRepo = customerRepo;
            _customerTypeRepo = customerTypeRepo;
        }
        [HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var customers = _customerRepo.GetAll(pageSize, pageNumber);
            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.customerTypes = new SelectList(
                _customerTypeRepo.GetALLWithoutPaging(),
                "CustomerTypeId",
                "CustomerTypeName");     // ← trainer uses "CustomerTypeName" (not CustomerTypName)

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Add(model);
                return RedirectToAction("Index");
            }

            ViewBag.customerTypes = new SelectList(
                _customerTypeRepo.GetALLWithoutPaging(),
                "CustomerTypeId",
                "CustomerTypeName",
                model.CustomerTypeId);     // ← trainer repopulates + passes selected value

            return View(model);            // ← trainer always returns View(model) on failure
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _customerRepo.GetById(id);
            ViewBag.customerTypes = new SelectList(_customerTypeRepo.GetALLWithoutPaging(), "CustomerTypeId", "CustomerTypName", model.CustomerTypeId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _customerRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
