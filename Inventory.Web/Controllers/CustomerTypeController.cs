using Inventory.Repository.CustomerTypeService;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class CustomerTypeController : Controller
    {
        private ICustomerTypeRepo _customerTypeRepo;

        public CustomerTypeController(ICustomerTypeRepo customerTypeRepo)
        {
            _customerTypeRepo = customerTypeRepo;
        }

        //[HttpGet]
        //public Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        //{
        //    var customerTypes = _customerTypeRepo.GetAll(pageSize, pageNumber);

        //    // Instead of 'return View(billTypes);'
        //    // We manually wrap the ViewResult into a Task to match the method signature
        //    return Task.FromResult<IActionResult>(View(customerTypes.Result));
        //}
        //[HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1,string? searching=null)
        {
            PageResult<CustomerTypeListViewModel> customerTypes;
            customerTypes = _customerTypeRepo.GetAll(pageSize, pageNumber);
            if (!String.IsNullOrEmpty(searching))
            {
                customerTypes = _customerTypeRepo.Search(searching, pageSize, pageNumber);
            }
            return View(customerTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCustomerTypeViewModel model)
        {

            if (ModelState.IsValid)
            {
                _customerTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _customerTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CustomerTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _customerTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
