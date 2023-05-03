using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringProject.Model
{
    public class Doctor
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Doctor()
        {
            autoIncreament++;
            Id = autoIncreament;
        }
    }
}
