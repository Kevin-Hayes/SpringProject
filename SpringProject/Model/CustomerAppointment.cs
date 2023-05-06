using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringProject.Model
{
    public class CustomerAppointment
    {
        public Customer customer { get; set; }

        public Appointment appointment { get; set; }

        public Doctor doctor { get; set; }


        public CustomerAppointment(Customer c, Appointment a, Doctor d) //allows patient to see their corresponding doctors and appointments
        {
            customer = c;
            appointment = a;
            doctor = d;
        }
    }
}
