using SpringProject.Model;

namespace SpringProject
{
    public class Program
    {
        private static Customers customers;
        private static List<Appointment> appointments;
        private static List<CustomerAppointment> customerAppointments;
        private static Customer authenticatedCustomer;
        private static List<Doctor> doctors;
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

            var d1 = new Doctor
            {
                FirstName = "John",
                LastName = "Smith"
            };

            var d2 = new Doctor
            {
                FirstName = "Jane",
                LastName = "Jones"
            };

            

            var a1 = new Appointment();
            var a2 = new Appointment();
            var a3 = new Appointment();



            var ca1 = new CustomerAppointment(c1, a1, d1);
            var ca2 = new CustomerAppointment(c1, a2, d2);
            var ca3 = new CustomerAppointment(c2, a3, d2);

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

            doctors = new List<Doctor>();
            doctors.Add(d1);
            doctors.Add(d2);



        }

        static void Menu()
        {
            bool done = false;

            while(!done)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("To login, press 1");
                Console.WriteLine("To logout, press 2");
                Console.WriteLine("To sign Up, press 3");
                Console.WriteLine("To view your appointments, press 4");
                Console.WriteLine("To see your doctors, press 5");
                Console.WriteLine("To clear the screen or quit the program, select c or q");
                Console.WriteLine("Choice: ");
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
                    case "5":
                        GetDoctorsMenu();
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

            while (done)
            {
                Console.WriteLine("To logout, press 2");
                Console.WriteLine("To view your appointments, press 4");
                Console.WriteLine("To see your doctors, press 5");
                Console.WriteLine("To clear the screen or quit the program, select c or q");
                Console.WriteLine("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "2":
                        LogoutMenu();
                        break;
                    case "4":
                        GetCurrentAppointmentsMenu();
                        break;
                    case "5":
                        GetDoctorsMenu();
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
                    Console.WriteLine(" ");
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
                    Console.WriteLine(" ");
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
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine(); 
            Console.Write("Username: ");
            string UserName = Console.ReadLine();
            Console.Write("Password: ");
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
                    Console.WriteLine(" ");
                    Console.WriteLine(appointment.appointment.currentDate);
                    Console.WriteLine(" ");
                }
            }


        }

        static void GetDoctorsMenu()
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine($"{i}: {doctors[i].LastName}{doctors[i].FirstName}");
            }
            Console.WriteLine("Enter corresponding number of doctor to select:");
            Console.ReadLine();


        }


    }
}