using DataAccess;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface ICustomersRepository
    {
        List<Customer> GetAllCustomers();

        Customer GetCustomerById(int id);

        void AddCustomer(Customer customerToAdd);

        void EditCustomer(int id,Customer customer);

        void DeleteCustomer(int id);
    }
}
