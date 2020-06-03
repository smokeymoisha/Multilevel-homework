using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Multilevel_Homework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customerManager = new CustomersManager();

            Console.WriteLine(customerManager.GetCustomerById("NS-77777"));

            Console.WriteLine("==========================");

            //List<Customer> customers = customerManager.GetAllCustomers().ToList();
            //customers.ForEach(Console.WriteLine);

            //Console.WriteLine("==========================");

            //customerManager.InsertCustomer("Test-ID2", "Axel", "Stone", 2, "Los Angeles");

            customerManager.DeleteCustomerById("Test-ID");

            List<Customer> customers = customerManager.GetAllCustomers().ToList();
            customers.ForEach(Console.WriteLine);
        }
    }
}
