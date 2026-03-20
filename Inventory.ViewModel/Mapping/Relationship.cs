using Inventory.Models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTypeListViewModel = Inventory.ViewModel.Product.ProductTypeListViewModel;

namespace Inventory.ViewModel.Mapping
{
    public static class Relationship
    {
        public static IEnumerable<CustomerTypeListViewModel> 
            ModelToVM(this IEnumerable<CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> List = new List<CustomerTypeListViewModel>();
            foreach (var ct in customerType)
            {
                List.Add(new CustomerTypeListViewModel()
                {

                    CustomerTypeId = ct.CustomerTypeId,
                    CustomerTypeName = ct.CustomerTypeName,
                    Description = ct.Description

                });

            }
            return List;
        }

        public static IEnumerable<CustomerListViewModel>
            ModelToVM(this IEnumerable<Inventory.Models.Customer> customers)
        {
            List<CustomerListViewModel> List = new List<CustomerListViewModel>();
            foreach (var ct in customers)
            {
                List.Add(new CustomerListViewModel()
                {

                    CustomerId = ct.CustomerId,
                    CustomerName = ct.CustomerName,
                    City = ct.City,
                    ContactPerson = ct.ContactPerson,
                    CustomerTypeId = ct.CustomerTypeId,
                    ZioCode = ct.ZioCode,
                    Address = ct.Address,
                    Email = ct.Email,
                    Phone = ct.Phone,

                });

            }
            return List;
        }

        public static IEnumerable<BillTypeListViewModel>
        ModelToVM(this IEnumerable<Inventory.Models.BillType> billTypes)
        {
            List<BillTypeListViewModel> List = new List<BillTypeListViewModel>();
            foreach (var ct in billTypes)
            {
                List.Add(new BillTypeListViewModel()
                {

                    BillTypeId = ct.BillTypeId,
                    BillTypeName = ct.BillTypeName,
                    Description = ct.Description
                });

            }
            return List;
        }

        public static IEnumerable<BillListViewModel>
            ModelToVM(this IEnumerable<Inventory.Models.Bill> bills)
        {
            List<BillListViewModel> List = new List<BillListViewModel>();
            foreach (var ct in bills)
            {
                List.Add(new BillListViewModel()
                {
                    BillDate = ct.BillDate,
                    BillDueDate = ct.BillDueDate,
                    BillId = ct.BillId,
                    BillName = ct.BillName,
                    BillTypeId=ct.BillTypeId,
                    GoodsRecievedNoteId = ct.GoodsRecievedNoteId,
                    VendorDoNumber  = ct.VendorDoNumber,
                    VendorInvoiceNumber = ct.VendorInvoiceNumber
                });

            }
            return List;
        }

        public static IEnumerable<ProductTypeListViewModel>
            ModelToVM(this IEnumerable<Inventory.Models.ProductType> productTypes)
        {
            List<ProductTypeListViewModel> List = new List<ProductTypeListViewModel>();
            foreach (var ct in productTypes)
            {
                List.Add(new ProductTypeListViewModel()
                {

                    ProductTypeId=ct.ProductTypeId,
                    ProductTypeName=ct.ProductTypeName,
                    Description=ct.Description

                });

            }
            return List;
        }

        public static IEnumerable<ProductListViewModel>
            ModelToVM(this IEnumerable<Inventory.Models.Product> products)
        {
            List<ProductListViewModel> List = new List<ProductListViewModel>();
            foreach (var ct in products)
            {
                List.Add(new ProductListViewModel()
                {
                    ProductId=ct.ProductId,
                    ProductName=ct.ProductName,
                    ProductCode=ct.ProductCode,
                    BarCode=ct.BarCode,
                    Description=ct.Description,
                    ProductImage=ct.ProductImage,
                    MeasureUnitId=ct.MeasureUnitId,
                    BuyingPrice=ct.BuyingPrice,
                    SellingPrice=ct.SellingPrice,
                    BranchId=ct.BranchId,
                    CurrencyId=ct.CurrencyId
                });

            }
            return List;
        }



    }
}
