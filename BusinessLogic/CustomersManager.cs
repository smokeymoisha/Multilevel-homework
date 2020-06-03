using RepositoryADO;
using RepositoryDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BusinessLogic
{
    public class CustomersManager
    {
        private ICustomerRepository customerRepository;

        public CustomersManager()
        {
            customerRepository = new CustomerRepositoryDapper();
        }

        public IList<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(string id)
        {
            return customerRepository.GetCustomerById(id);
        }

        public int InsertCustomer(string id, string firstName, string lastName, int segment, string city)
        {
            return customerRepository.InsertCustomer(id, firstName, lastName, segment, city);
        }

        public int DeleteCustomerById(string id)
        {
            return customerRepository.DeleteCustomerById(id);
        }
    }
}
