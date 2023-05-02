using SpringProject.Model;

namespace SpringProject
{
    public class Program
    {
        private static Customers customers;
        private static List<Appointment> appointments;
        private static List<CustomerAppointment> customerAppointments;
        private static Customer authenticatedCustomer;
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            Initialize();
            Menu();
        }

        static void Initialize()
        {
            var c1 = new Customer
            {
                FirstName= "Test",
                LastName= "TEST",
                UserName= "test",
                Password= "1234",
            };
            var c2 = new Customer
            {
                FirstName = "Kevin",
                LastName = "Hayes",
                UserName = "test",
                Password = "12345"
            };

            var a1 = new Appointment();
            var a2 = new Appointment();
            var a3 = new Appointment();

            var ca1 = new CustomerAppointment(c1, a1);
            var ca2 = new CustomerAppointment(c1, a2);
            var ca3 = new CustomerAppointment(c2, a3);

            customers = new Customers();
            customers.customers.Add(c1);
            customers.customers.Add(c2);

            appointments= new List<Appointment>();
            appointments.Add(a1);
            appointments.Add(a2);
            appointments.Add(a3);

            customerAppointments = new List<CustomerAppointment>();
            customerAppointments.Add(ca1);
            customerAppointments.Add(ca2); 
            customerAppointments.Add(ca3);


        }

        static void Menu()
        {
            bool done = false;

            while(!done)
            {
                Console.WriteLine("Options: Login: 1 --- Logout: 2 --- Sign Up: 3 --- Appointments: 4 --- Clear Screen: c --- Quit: q ---");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        LogoutMenu();
                        break;
                    case "3":
                        SignUpMenu();
                        break;
                    case "4":
                        GetCurrentAppointmentsMenu();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }

        }



        
        static void LoginMenu()
        {
            if(authenticatedCustomer == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                customers.Authenticate(username, password);
                authenticatedCustomer = customers.Authenticate(username, password);
                if (authenticatedCustomer != null)
                {
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
                }
                else
                {
                    Console.WriteLine("invlaid usernmae or password");
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.UserName}");
            }

        }

        static void LogoutMenu()
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out");
        }

        static void SignUpMenu()
        {
            Console.Write("First Name: ");
            string FirstName = Console.ReadLine();
            Console.Write("First Name: ");
            string LastName = Console.ReadLine(); 
            Console.Write("First Name: ");
            string UserName = Console.ReadLine();
            Console.Write("First Name: ");
            string Password = Console.ReadLine();

            
            var newCustomer = new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Password = Password
            };

            customers.customers.Add(newCustomer);

            Console.WriteLine("Profile created!");

        }

        static void GetCurrentAppointmentsMenu()
        {
            if(authenticatedCustomer == null)
            {
                Console.WriteLine("You are not logged in.");
                return;
            }

            var appointmentsList = customerAppointments.Where(o => o.customer.UserName == authenticatedCustomer.UserName);

            if(appointmentsList.Count() == 0)
            {
                Console.WriteLine("0 appointment found.");
            }
            else
            {
                foreach(var appointment in appointmentsList)
                {
                    Console.WriteLine(appointment.appointment.date);
                }
            }


        }


    }
}