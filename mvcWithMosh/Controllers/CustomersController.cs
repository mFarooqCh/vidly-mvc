using System;
using System.Linq;
using System.Web.Mvc;
using mvcWithMosh.Models;
using System.Data.Entity;
using mvcWithMosh.ViewModels;

namespace mvcWithMosh.Controllers
{
    public class CustomersController : Controller, IDisposable
    {
        private readonly AppDbContext DB;

        public CustomersController()
        {
            DB = new AppDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customer = DB.Customer.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
        public ActionResult Details(int id)
        {
            var customer = DB.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ViewResult New()
        {
            var merbershipType = DB.MembershipType.ToList();
            var viewModel = new NewCustomerVM
            {
                MembershipTypes = merbershipType,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(NewCustomerVM newCustomer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerVM
                {
                    Customer = newCustomer.Customer,
                    MembershipTypes = DB.MembershipType.ToList()
                };
                return View(viewModel);
            }

            DB.Customer.Add(newCustomer.Customer);
            DB.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            var customer = DB.Customer.SingleOrDefault(c => c.Id == id);

            var viewModel = new NewCustomerVM
            {
                Customer = customer,
                MembershipTypes = DB.MembershipType.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(NewCustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                var customerOldData = DB.Customer.FirstOrDefault(c => c.Id == customerVM.Customer.Id);
                if (customerOldData != null)
                {
                    customerOldData.Name = customerVM.Customer.Name;
                    customerOldData.DateOfBirth = customerVM.Customer.DateOfBirth;
                    customerOldData.IsSubscriber = customerVM.Customer.IsSubscriber;
                    customerOldData.MembershipTypeId = customerVM.Customer.MembershipTypeId;
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}