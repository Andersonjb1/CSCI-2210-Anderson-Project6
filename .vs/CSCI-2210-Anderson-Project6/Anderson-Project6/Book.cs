﻿namespace Anderson_Project6
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }

        //public Book(string title, string author, int pages, string publisher)
        //{
        //    Title = title;
        //    Author = author;
        //    Pages = pages;
        //    Publisher = publisher;
        //}

        public void Print() //displays the title, author, number of pages, and publisher of the book
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Title: " + Title);
            Console.ForegroundColor= ConsoleColor.Gray;
            Console.WriteLine("Author: " + Author + "\n"
                             +"Pages: " + Pages + "\n" 
                             +"Publisher: " + Publisher + "\n");

        }
    }
}
