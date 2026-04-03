using Inventory.Repository.ProductTypeService;
using Inventory.Repository.Purchase;
using Inventory.ViewModel.Product;
using Inventory.ViewModel.Purchase;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class ProductTypesController : Controller
    {
        private IProductTypeRepo _productTypeRepo;

        public ProductTypesController(IProductTypeRepo productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
        }
        //[HttpGet]
        //public Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        //{
        //    var billTypes = _productTypeRepo.GetAll(pageSize, pageNumber);

        //    // Instead of 'return View(billTypes);'
        //    // We manually wrap the ViewResult into a Task to match the method signature
        //    return Task.FromResult<IActionResult>(View(billTypes.Result));
        //}
        //[HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var productTypes = _productTypeRepo.GetAll(pageSize, pageNumber);
            return View(productTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductTypeViewModel model)
        {

            if (ModelState.IsValid)
            {
                _productTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _productTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            _productTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
