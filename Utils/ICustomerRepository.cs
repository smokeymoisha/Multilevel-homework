using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAllCustomers();

        Customer GetCustomerById(string id);

        int InsertCustomer(string id, string firstName, string lastName, int segment, string city);

        int DeleteCustomerById(string id);
    }
}
