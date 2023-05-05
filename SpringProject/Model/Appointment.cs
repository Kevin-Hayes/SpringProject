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
        public DateTime currentDate = DateTime.Now; /*We wanted to use a random date generator but were unable to do so, 
                                                     so the appointment date and time will just be the current date and time.*/

        public Appointment()
        {
            autoIncreament++;
            Id = autoIncreament;
        }

    }
}
