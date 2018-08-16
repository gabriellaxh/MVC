using DataAccess;
using MVC.Models;
using Repository.Contracts;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository _service;

        // GET: Customer
        //static List<CustomerModel> customers = new List<CustomerModel>
        //{
        //    new CustomerModel
        //    {
        //        Id = 2,
        //        Firstname = "Ivan",
        //        Lastname = "Petrov",
        //        PhoneNumber = "0891234865",
        //        SecondPhoneNumber = "0286345",
        //        Address = "ul. Momina salza 15"
        //    },
        //    new CustomerModel
        //    {
        //        Id= 4,
        //        Firstname = "Simona",
        //        Lastname = "Dimitrova",
        //        PhoneNumber = "0886345912",
        //        SecondPhoneNumber = "0234568",
        //        Address = "ul. Shipchenska"
        //    }
        //};

        public CustomersController(ICustomersRepository repository)
        {
            _service = repository;
        }

        public ActionResult Index()
        {
            var customers = _service.GetAllCustomers();

            var mappedCustomers = new List<CustomerModel>();

            foreach (var customer in customers)
            {
                var mappedCustomer = new CustomerModel
                {
                    Id = customer.Id,
                    Firstname = customer.Firstname,
                    Lastname = customer.Lastname,
                    PhoneNumber = customer.PhoneNumber,
                    SecondPhoneNumber = customer.SecondPhoneNumber,
                    Address = customer.Address
                };

                mappedCustomers.Add(mappedCustomer);
            }

            return View(mappedCustomers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerModel customerToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View(customerToAdd);
            }

            var mappedCustomer = new Customer
            {
                Id = customerToAdd.Id,
                Firstname = customerToAdd.Firstname,
                Lastname = customerToAdd.Lastname,
                PhoneNumber = customerToAdd.PhoneNumber,
                SecondPhoneNumber = customerToAdd.SecondPhoneNumber,
                Address = customerToAdd.Address
            };

            _service.AddCustomer(mappedCustomer);

            return RedirectToAction(nameof(Index));

        }

        public ActionResult Edit(int id)
        {
            var customerToEdit = _service.GetCustomerById(id);

            var mappedCustomer = new CustomerModel
            {
                Id = customerToEdit.Id,
                Firstname = customerToEdit.Firstname,
                Lastname = customerToEdit.Lastname,
                PhoneNumber = customerToEdit.PhoneNumber,
                SecondPhoneNumber = customerToEdit.SecondPhoneNumber,
                Address = customerToEdit.Address
            };

            return View(mappedCustomer);
        }

        [HttpPost]
        public ActionResult Edit(int id, CustomerModel customerToEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(customerToEdit);
            }

            var mappedCustomer = new Customer
            {
                Id = customerToEdit.Id,
                Firstname = customerToEdit.Firstname,
                Lastname = customerToEdit.Lastname,
                PhoneNumber = customerToEdit.PhoneNumber,
                SecondPhoneNumber = customerToEdit.SecondPhoneNumber,
                Address = customerToEdit.Address
            };

            _service.EditCustomer(id, mappedCustomer);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            var customerWanted = _service.GetCustomerById(id);

            var mappedCustomer = new CustomerModel
            {
                Id = customerWanted.Id,
                Firstname = customerWanted.Firstname,
                Lastname = customerWanted.Lastname,
                PhoneNumber = customerWanted.PhoneNumber,
                SecondPhoneNumber = customerWanted.SecondPhoneNumber,
                Address = customerWanted.Address
            };

            return View(mappedCustomer);
        }

        public ActionResult Delete(int id)
        {
            _service.DeleteCustomer(id);

            return RedirectToAction(nameof(Index));
        }
    }
}