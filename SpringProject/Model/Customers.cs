using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringProject.Model
{
    public class Customers
    {
        public List<Customer> customers { get; set; }

        public Customers()
        {
            customers = new List<Customer>();
        }

        public Customer Authenticate(string username, string password)
        {
            Customer c = customers.Where(o => o.UserName == username).First();
            if (c != null)
            {
                if (c.Password == password)
                {
                    return c;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
