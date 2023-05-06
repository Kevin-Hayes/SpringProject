using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringProject.Model
{
    public class Doctor //getters and setters used for validation
    {
        private static int autoIncreament;
        public int Id { get; set; } //doctors id is an integer
        public string FirstName { get; set; } // first and last names are strings
        public string LastName { get; set; }

        public Doctor()
        {
            autoIncreament++;
            Id = autoIncreament;
        }
    }
}
