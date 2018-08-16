using DataAccess;
using Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Services
{
    public class CustomerService : ICustomersRepository
    {
        public List<Customer> GetAllCustomers()
        {
            using (var context = new OnlineShopEntities())
            {
                var allCustomers = context.Customers.ToList();

                return allCustomers;
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (var context = new OnlineShopEntities())
            {
                var customerById = context.Customers.First(x => x.Id == id);

                return customerById;
            }
        }

        public void AddCustomer(Customer customerToAdd)
        {
            using (var context = new OnlineShopEntities())
            {
                var newCusomer = new Customer
                {
                    Id = customerToAdd.Id,
                    Firstname = customerToAdd.Firstname,
                    Lastname = customerToAdd.Lastname,
                    PhoneNumber = customerToAdd.PhoneNumber,
                    SecondPhoneNumber = customerToAdd.SecondPhoneNumber,
                    Address = customerToAdd.Address
                };

                context.Customers.Add(newCusomer);
                context.SaveChanges();
            }
        }

        public void EditCustomer(int id, Customer customerToEdit)
        {
            using (var context = new OnlineShopEntities())
            {
                var customer = context.Customers.FirstOrDefault(x => x.Id == id);

                if (customer != null)
                {
                    customer.Firstname = customerToEdit.Firstname;
                    customer.Lastname = customerToEdit.Lastname;
                    customer.PhoneNumber = customerToEdit.PhoneNumber;
                    customer.SecondPhoneNumber = customerToEdit.SecondPhoneNumber;
                    customer.Address = customerToEdit.Address;
                }

                context.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            using (var context = new OnlineShopEntities())
            {
                var customerToDel = context.Customers.First(x => x.Id == id);

                if (customerToDel != null)
                {

                    var ordersToDelete = context.Orders.Where(o => o.CustomerId == customerToDel.Id);

                    foreach (var order in ordersToDelete)
                    {
                        var orderItemsToDelete = context.OrderItems.Where(oi => oi.OrderId == order.Id);

                        foreach (var orderItem in orderItemsToDelete)
                        {
                            context.OrderItems.Remove(orderItem);
                        }

                        context.Orders.Remove(order);
                    }
                    context.Customers.Remove(customerToDel);
                }

                context.SaveChanges();
            }
        }
    }
}
