﻿using SpringProject.Model;

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
            var c1 = new Customer //c1 and c2 are made up customers that can be used to login into the program without siging up
            {
                FirstName= "Stephen",
                LastName= "Curry",
                UserName= "test1",
                Password= "1234",
            };
            var c2 = new Customer
            {
                FirstName = "Kevin",
                LastName = "Hayes",
                UserName = "test2",
                Password = "12345"
            };

            var d1 = new Doctor //d1 and d2 are made up doctors that are assigned to patients
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
                Console.WriteLine("Options:"); // the following 8 lines display the options a patient has when they open the program
                Console.WriteLine("To login, press 1");
                Console.WriteLine("To logout, press 2");
                Console.WriteLine("To sign Up, press 3");
                Console.WriteLine("To view your appointments, press 4");
                Console.WriteLine("To see your doctors, press 5");
                Console.WriteLine("To clear the screen or quit the program, select c or q");
                Console.WriteLine("Choice: "); // on this line the patient enters their their option
                string choice = Console.ReadLine(); // the patients input is read by the program
                switch (choice) // based on the patients choice the correct  menu will be triggered
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


        }



        
        static void LoginMenu() //this is the login menu. The patient is asked to enter a valid username and password.
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
                    Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}"); // They are then welcomed
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("invlaid usernmae or password"); // The program will let them know if their username and password are incorrect
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedCustomer.UserName}"); // It will also let them know if the are already logged in
            }

        }

        static void LogoutMenu() // The logout will log the user out
        {
            authenticatedCustomer = null;
            Console.WriteLine("Logged out");
        }

        static void SignUpMenu() // This is the signup menu. The pateint is asked to enter their name and create a username and password
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

        static void GetCurrentAppointmentsMenu() //This menu will show the customer their appointments. 
        {
            if(authenticatedCustomer == null)
            {
                Console.WriteLine("You are not logged in."); //If the patient is not logged in, they will not be shown appointments
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

        static void GetDoctorsMenu() // The doctors menu will show the names of the doctors
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine($"{i}: {doctors[i].LastName}, {doctors[i].FirstName}");
            }
            Console.WriteLine("Enter doctor's corresponding number: ");
            Console.ReadLine();
        }


    }
}