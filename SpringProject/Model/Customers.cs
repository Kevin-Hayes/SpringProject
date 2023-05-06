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

        public Customer Authenticate(string username, string password) //The username and password are authenticated
        {
            var c = customers.Where(o => (o.UserName == username) && (o.Password == password ));

            if (c.Count() > 0)
            {
                return c.First();
            }
            else
            {
                return null;
            }
            
        }
    }
}
