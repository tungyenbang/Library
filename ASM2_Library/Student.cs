using ASM2_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library
{
    class Student : User
    {
        private string phoneNumber;
        private string email;
        private string address;
        public Student(string phone, string email, string address)
        {
            PhoneNumber = phone;
            Email = email;
            Address = address;
        }
        public Student()
        {
            if (Program.students.Count > 0)
            {
                int setID = Program.students.ElementAt(Program.students.Count - 1).ID;
                this.id = setID + 1;
            }
            else { this.id = 1; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The phone number can't be null");
                }
                if (!IsNumber(value))
                {
                    throw new ArgumentException("The phone number must be numeric");
                }
                phoneNumber = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The email can't be null");
                }
                if (!IsValidEmail(value))
                {
                    throw new ArgumentException("The email isn't valided");
                }
                email = value;
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The address can't be null");
                }
                address = value;
            }
        }
        public override void ViewSystem()
        {
            Console.WriteLine("-------------Welcome to Library  ------------");
            Console.WriteLine("| 1,View your profile                       |");
            Console.WriteLine("| 2,Edit your profile                       |");
            Console.WriteLine("| 3,View all books                          |");
            Console.WriteLine("| 4,Search books in library                 |");
            Console.WriteLine("| 5,Logout                                  |");
            Console.WriteLine(" --------------------------------------------");
        }

        public void ViewProfile(int id)
        {
            foreach (var Student in Program.students)
            {
                if (Student.ID == id)
                {
                    Console.WriteLine("--------------Your Profile------------------");
                    Console.WriteLine($"1, Your name:{Student.UserName}");
                    Console.WriteLine($"2, Your phone number:{Student.PhoneNumber}");
                    Console.WriteLine($"3, Your email:{Student.Email}");
                    Console.WriteLine($"4, Your address:{Student.Address}");
                }
            }

        }
        public void EditProfile(int id)
        {
            Console.WriteLine("Enter your phone number:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your address:");
            string address = Console.ReadLine();
            try
            {
                Student student = Program.students.Find(c => c.ID == id);
                student.PhoneNumber = phone;
                student.Email = email;
                student.Address = address;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ViewAllBook()
        {
            Console.WriteLine("---------The list of books-----------");
            foreach (var book in Program.books)
            {
                if (book.CheckAvailable() == true)
                {
                    Console.WriteLine($"ID: {book.ID} Name: {book.Name}" +
                        $" Name Author: {book.NameAu} Description: {book.Description}");
                }
            }
            Console.WriteLine("-----------------------------------------");
        }
        public void Search()
        {
            Console.WriteLine("Enter the name of the books you want to search");
            string name = Console.ReadLine();
            Console.WriteLine("------------------The list of products--------------------");
            foreach (var book in Program.books)
            {
                if (book.Name.Contains(name))
                {
                    Console.WriteLine($"ID: {book.ID} Name: {book.Name}" +
                        $" Name Author: {book.NameAu} Description: {book.Description}");
                }
            }
        }
    }
}
