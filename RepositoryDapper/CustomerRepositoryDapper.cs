using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Utils;

namespace RepositoryDapper
{
    public class CustomerRepositoryDapper : ICustomerRepository
    {
        private readonly string connection;

        public CustomerRepositoryDapper()
        {
            connection = ConfigurationManager.ConnectionStrings["Orders"].ConnectionString;
        }

        public int DeleteCustomerById(string id)
        {
            using (var sqlConnection = new SqlConnection(connection))
            {
                string commandText = "Delete from customers where customer_id = @param_id";

                int affectedRows = sqlConnection.Execute(commandText, new { param_id = id });

                return affectedRows;
            }

        }

        public IList<Customer> GetAllCustomers()
        {
            using (var sqlConnection = new SqlConnection(connection))
            {
                string command = "Select customer_id, first_name, last_name, segment_name as 'Segment', city " +
                                "From customers cus, segments seg " +
                                "Where seg.segment_id = cus.segment";

                var customers = sqlConnection.Query<Customer>(command).AsList();

                return customers;
            }
        }

        public Customer GetCustomerById(string id)
        {
            using (var sqlConnection = new SqlConnection(connection))
            {
                string commandText = "Select customer_id, first_name, last_name, segment_name as 'Segment', city " +
                "From customers cus, segments seg " +
                "Where seg.segment_id = cus.segment AND cus.customer_id = @param_id";

                var customer = sqlConnection.Query<Customer>(commandText, new { param_id = id });

                return customer.FirstOrDefault();
            }
        }

        public int InsertCustomer(string id, string firstName, string lastName, int segment, string city)
        {
            using (var sqlConnection = new SqlConnection(connection))
            {
                string commandText = "Insert into customers values (@id, @first_name, @last_name, @segment, @city)";

                int affectedRows = sqlConnection.Execute(commandText,
                    new { id = id, first_name = firstName, last_name = lastName, segment = segment, city = city });

                return affectedRows;
            }
        }
    }
}
