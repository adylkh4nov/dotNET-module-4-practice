using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_4_practice
{
    public class Book
    {   
        public Book() : this("")
        {}
        public Book(string Title) : this(Title,"")
        { }
        public Book(string Title, string Author) : this (Title,Author,0)
        { }
        public Book(string Title,string Author,int year)
        {
            this.Title = Title;
            this.Author = Author;
            this.Year = year;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author} ({Year})";
        }
    }
}
