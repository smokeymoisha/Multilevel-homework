using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace RepositoryADO
{
    public class CustomerRepositoryADO : ICustomerRepository
    {
        private readonly string connection;

        public CustomerRepositoryADO()
        {
            connection = ConfigurationManager.ConnectionStrings["Orders"].ConnectionString;
        }

        public int DeleteCustomerById(string id)
        {
            using (var sqlConnection = new SqlConnection(connection))
            {
                string commandText = "Delete from customers where customer_id = @param_id";

                SqlCommand command = new SqlCommand(commandText, sqlConnection);

                command.Parameters.Add("@param_id", SqlDbType.VarChar);
                command.Parameters["@param_id"].Value = id;

                int affectedRows = command.ExecuteNonQuery();

                return affectedRows;
            }
           
        }

        public IList<Customer> GetAllCustomers()
        {
            string command = "Select customer_id, first_name, last_name, segment_name, city " +
                "From customers cus, segments seg " +
                "Where seg.segment_id = cus.segment";

            var adapter = new SqlDataAdapter(command, connection);

            var customerSet = new DataSet();

            adapter.Fill(customerSet, "Customers");

            DataTable customerTable = customerSet.Tables["Customers"];

            var customers = new List<Customer>();

            foreach(DataRow row in customerTable.Rows)
            {
                customers.Add(new Customer(
                    (string)row[0],
                    (string)row[1],
                    (string)row[2],
                    (string)row[3],
                    (string)row[4]));
            }

            return customers;
        }

        public Customer GetCustomerById(string id)
        {
            string commandText = "Select customer_id, first_name, last_name, segment_name, city " +
                "From customers cus, segments seg " +
                "Where seg.segment_id = cus.segment AND cus.customer_id = @param_id";

            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand command = new SqlCommand(commandText, sqlConnection);

            command.Parameters.Add("@param_id", SqlDbType.VarChar);
            command.Parameters["@param_id"].Value = id;

            var adapter = new SqlDataAdapter(command);

            var customerSet = new DataSet();
            adapter.Fill(customerSet, "Customer");

            var customerTable = customerSet.Tables["Customer"];
            var row = customerTable.Rows[0];

            Customer customer = new Customer(
                (string)row[0],
                (string)row[1],
                (string)row[2],
                (string)row[3],
                (string)row[4]);

            return customer;
        }

        public int InsertCustomer(string id, string firstName, string lastName, int segment, string city)
        {
            using (var sqlConnection = new SqlConnection(connection))
            {
                string commandText = "Insert into customers values (@id, @first_name, @last_name, @segment, @city)";

                SqlCommand command = new SqlCommand(commandText, sqlConnection);

                command.Parameters.Add("@id", SqlDbType.VarChar);
                command.Parameters["@id"].Value = id;

                command.Parameters.Add("@first_name", SqlDbType.VarChar);
                command.Parameters["@first_name"].Value = firstName;

                command.Parameters.Add("@last_name", SqlDbType.VarChar);
                command.Parameters["@last_name"].Value = lastName;

                command.Parameters.Add("@segment", SqlDbType.Int);
                command.Parameters["@segment"].Value = segment;

                command.Parameters.Add("@city", SqlDbType.VarChar);
                command.Parameters["@city"].Value = city;

                int affectedRows = command.ExecuteNonQuery();

                return affectedRows;
            }
        }
    }
}
