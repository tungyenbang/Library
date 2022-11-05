using ASM2_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library
{
    internal class Book
    {

        private int id;
        private string name;
        private string description;
        private string nameAu;
        private int number;

        public int ID
        {
            get { return id; }

        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name can't be null");
                }
                name = value;
            }
        }
        public string NameAu
        {
            get { return nameAu; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name can't be null");
                }
                nameAu = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (value == null) { throw new ArgumentNullException("The description can't be null"); }
                description = value;
            }
        }

        public int Number
        {
            get { return number; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The quantity can't be null");
                }
                number = value;
            }
        }

        public Book(string name, string description, string nameAu, int number)
        {
            if (Program.books.Count > 0)
            {
                int setID = Program.books.ElementAt(Program.books.Count - 1).ID;
                this.id = setID + 1;
            }
            else { this.id = 1; }
            Name = name;
            Description = description;
            NameAu = nameAu;
            Number = number;
        }

        public override string ToString()
        {
            return $"ID: {id} Name: {Name} Number Page: {Number} Name Author: {NameAu} Description: {Description}";
        }

        public bool CheckAvailable()
        {
            if (Number > 0) { return true; }
            return false;
        }
        public bool CheckDuplicated(string name)
        {
            foreach (Book product in Program.books)
            {
                if (product.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
