using ASM2_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library
{
    class Librarian : User, IManageBook
    {
        private string phone;
        private string email;

        public string PhoneNumber
        {
            get { return phone; }
            set
            {
                if (value == " ")
                {
                    throw new ArgumentException("The phone number can't be null");
                }
                if (!IsNumber(value))
                {
                    throw new ArgumentException("The phone number must be numeric");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value == " ")
                {
                    throw new ArgumentException("The email can't be null");
                }
                if (!IsValidEmail(value))
                {
                    throw new ArgumentException("The email isn't valided");
                }
                email = value;
            }
        }

        public override void ViewSystem()
        {
            Console.WriteLine("-------Welcome to the librarian system--------");
            Console.WriteLine("| 1,View all book                            |");
            Console.WriteLine("| 2,Add a new book                           |");
            Console.WriteLine("| 3,Update for a book                        |");
            Console.WriteLine("| 4,Remove a book                            |");
            Console.WriteLine("| 5,Logout                                   |");
            Console.WriteLine("----------------------------------------------");
        }

        public void AddNewBook()
        {
            Console.WriteLine("Enter name for the book:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter author of the book:");
            string nameAu = Console.ReadLine();
            Console.WriteLine("Enter book page number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter description for the book:");
            string description = Console.ReadLine();
            try
            {
                Book book = new Book(name, description, nameAu, number);
                if (!book.CheckDuplicated(name))
                {
                    Program.books.Add(book);
                    Console.WriteLine("The book was added");
                }
                else { Console.WriteLine("This name was used for other book"); }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewAllBook()
        {
            Console.WriteLine("------------------The list of books--------------------");
            foreach (var book in Program.books)
            {
                Console.WriteLine($"ID: {book.ID} Name: {book.Name}" +
                        $" Name Author: {book.NameAu} Description: {book.Description}");
            }
            Console.WriteLine("-----------------------------------------------------------");
        }

        public void DeleteBook()
        {
            int IDRemovedProduct = -1;
            Console.WriteLine("Enter the ID of the book you want to remove:");
            int id = int.Parse(Console.ReadLine());
            foreach (Book book in Program.books)
            {
                if (book.ID == id)
                {
                    IDRemovedProduct = book.ID;
                }
            }
            if (IDRemovedProduct > 0)
            {
                Program.books.Remove(Program.books.Find(p => p.ID == IDRemovedProduct));
                Console.WriteLine("The book was removed");
            }
            else
            {
                Console.WriteLine("This book doesn't exits!!!");
            }

        }

        public void UpdateBook()
        {
            int IDBookUpdate = -1;
            Console.WriteLine("Please enter id of the book that you want to update");
            int idBook = int.Parse(Console.ReadLine());
            foreach (var book in Program.books)
            {
                if (idBook == book.ID)
                {
                    IDBookUpdate = book.ID;
                }
            }
            if (IDBookUpdate > 0)
            {
                Console.WriteLine("Enter name for the book:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter author of the book:");
                string nameAu = Console.ReadLine();
                Console.WriteLine("Enter book page number:");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter description for the book:");
                string description = Console.ReadLine();
                try
                {
                    Book UpdatedBook = Program.books.Find(p => p.ID == IDBookUpdate);
                    UpdatedBook.NameAu = nameAu;
                    UpdatedBook.Number = number;
                    UpdatedBook.Description = description;
                    UpdatedBook.Name = name;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else { Console.WriteLine("This book doesn't exist"); }
        }
    }
}
