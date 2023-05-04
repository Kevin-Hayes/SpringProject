using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringProject.Model
{
    public class Appointment
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public DateTime currentDate = DateTime.Now;

        public Appointment()
        {
            autoIncreament++;
            Id = autoIncreament;
        }

    }
}
