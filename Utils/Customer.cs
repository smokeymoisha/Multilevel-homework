using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(string id, string firstName, string lastName, string segment, string city)
        {
            Customer_Id = id;
            First_Name = firstName;
            Last_Name = lastName;
            Segment = segment;
            City = city;
        }

        public string Customer_Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Segment { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return $"Customer {Customer_Id}: {First_Name} {Last_Name} from {City}, segment: {Segment}";
        }
    }
}
