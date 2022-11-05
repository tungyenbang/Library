using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ASM2_Library
{
    internal class Program
    {
        public static List<Student> students = new List<Student>();
        public static List<Librarian> librarians = new List<Librarian>();
        public static List<Book> books = new List<Book>();

        private static void Main(string[] args)
        {
            Librarian Li = new Librarian();
            Li.UserName = "Tung";
            Li.Password = "123456";
            librarians.Add(Li);
            Book book = new Book("TY", "good", "Tung", 160);
            books.Add(book);
            Welcome();

        }

        public static void Welcome()
        {
            int currentID;
            string choice = "";
            bool check = true;
            do
            {
                Console.WriteLine("     --------------------Welcome to the system--------------");
                Console.WriteLine("     | 1,Enter 1 to register an account                    |");
                Console.WriteLine("     | 2,Enter 2 to login as a student                     |");
                Console.WriteLine("     | 3,Enter 3 to login as a librarian                   |");
                Console.WriteLine("     -------------------------------------------------------");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Student student = new Student();
                        student.Register();
                        try
                        {
                            students.Add(student);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "2":
                        string cmd = "";
                        int checkStudentID = LoginStudent();
                        Console.Write("Your ID: " + checkStudentID);
                        if (checkStudentID >= 0)
                        {
                            Console.WriteLine("You login successfully");
                            currentID = checkStudentID;
                            Student student2 = CurrentStudent(currentID);
                            do
                            {
                                student2.ViewSystem();
                                cmd = Console.ReadLine();
                                switch (cmd)
                                {
                                    case "1":
                                        student2.ViewProfile(currentID);
                                        break;
                                    case "2":
                                        student2.EditProfile(currentID);
                                        break;
                                    case "3":
                                        student2.ViewAllBook();
                                        break;
                                    case "4":
                                        student2.Search();
                                        break;
                                    case "5":
                                        Console.WriteLine("Goodbye");
                                        break;
                                    default:
                                        Console.WriteLine("Please enter 1 to 5");
                                        break;
                                }

                            } while (cmd != "5");
                        }
                        else
                        {
                            Console.WriteLine("Password or username isn't correct");
                        }
                        break;
                    case "3":
                        string command = "";
                        int checkAdminID = LoginLibrarian();
                        if (checkAdminID >= 0)
                        {
                            Console.WriteLine("You login successfully");
                            currentID = checkAdminID;
                            Librarian Li = CurrentLibrarian(currentID);
                            do
                            {
                                Li.ViewSystem();
                                command = Console.ReadLine();
                                switch (command)
                                {
                                    case "1":
                                        Li.ViewAllBook();
                                        break;
                                    case "2":
                                        Li.AddNewBook();
                                        break;
                                    case "3":
                                        Li.UpdateBook();
                                        break;
                                    case "4":
                                        Li.DeleteBook();
                                        break;
                                    case "5":
                                        Console.WriteLine("Goodbye");
                                        break;
                                    default:
                                        Console.WriteLine("Please input from 1 to 8");
                                        break;
                                }
                            } while (command != "5");
                        }
                        else
                        {
                            Console.WriteLine("Password or username isn't correct");
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter from 1 to 3");
                        break;
                }
            } while (check == true);
        }

        public static int LoginStudent()
        {
            Console.WriteLine("Please enter student name");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter password");
            string pass = Console.ReadLine();
            for (int i = 0; i < students.Count; i++)
            {
                if (name == students.ElementAt(i).UserName && pass == students.ElementAt(i).Password)
                {
                    return students.ElementAt(i).ID;
                }
            }
            return -1;
        }

        public static int LoginLibrarian()
        {
            Console.WriteLine("Please enter librarian name");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter password");
            string pass = Console.ReadLine();
            for (int i = 0; i < librarians.Count; i++)
            {
                if (name == librarians.ElementAt(i).UserName && pass == librarians.ElementAt(i).Password)
                {
                    return librarians.ElementAt(i).ID;
                }
            }
            return -1;
        }

        public static Librarian CurrentLibrarian(int id)
        {
            for (int i = 0; i < librarians.Count; i++)
            {
                if (librarians[i].ID == id) return librarians[i];
            }
            return librarians[0];
        }

        public static Student CurrentStudent(int id)
        {
            for (int i = 0; i < librarians.Count; i++)
            {
                if (students[i].ID == id) return students[i];
            }
            return students[0];
        }
    }
}
