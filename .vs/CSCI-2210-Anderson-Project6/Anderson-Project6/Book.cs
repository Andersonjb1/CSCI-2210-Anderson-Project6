///////////////////////////////////////////////////////////////////////////////
//
// Author: Blaine Anderson, Andersonjb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 6
// Description: Project demonstrating understanding of AVLTrees
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Anderson_Project6
{
    /// <summary>
    /// 
    /// </summary>
    internal class Book : IComparable<Book>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Pages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Book()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="pages"></param>
        /// <param name="publisher"></param>
        public Book(string title, string author, int pages, string publisher)
        {
            this.Title = title;
            this.Author = author;
            this.Pages = pages;
            this.Publisher = publisher;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print() //displays the title, author, number of pages, and publisher of the book
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Title: " + Title);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Author: " + Author + "\n"
                             + "Pages: " + Pages + "\n"
                             + "Publisher: " + Publisher + "\n");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int CompareTo(Book? book)
        {
            if (Key.CompareTo(book.Key) == 0)
            {
                return 0;
            }
            else if (Key.CompareTo(book.Key) == -1)
            {
                return -1;
            }
            else return 1;

        }//comment to let me commit to GitHub

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void SetKey(string input)
        {
            Dictionary<string, Action> keySetter = new();
            keySetter["TITLE"] = () => { Key = this.Title; };
            keySetter["AUTHOR"] = () => { Key = this.Author; };
            keySetter["PUBLISHER"] = () => { Key = this.Publisher; };

            if (keySetter.ContainsKey(input.ToUpper()))
                keySetter[input.ToUpper()]();
        }
    }
}
