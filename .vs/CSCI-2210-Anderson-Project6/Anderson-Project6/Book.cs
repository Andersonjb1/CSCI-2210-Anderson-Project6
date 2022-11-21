using System;
using System.Collections.Generic;
using System.Text;

namespace Anderson_Project6
{
    internal class Book : IComparable<Book>
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? Pages { get; set; }
        public string? Publisher { get; set; }

        public Book()
        {

        }

        public Book(string title, string author, int pages, string publisher)
        {
            this.Title = title;
            this.Author = author;
            this.Pages = pages;
            this.Publisher = publisher;
        }

        public void Print() //displays the title, author, number of pages, and publisher of the book
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Title: " + Title);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Author: " + Author + "\n"
                             + "Pages: " + Pages + "\n"
                             + "Publisher: " + Publisher + "\n");

        }

        public int CompareTo(Book? book)
        {
            if (Title.CompareTo(book.Title) == 0)
            {
                return 0;
            }
            else if (Title.CompareTo(book.Title) == -1)
            { 
                return -1;
            }
            else return 1;

        }
    }
}
