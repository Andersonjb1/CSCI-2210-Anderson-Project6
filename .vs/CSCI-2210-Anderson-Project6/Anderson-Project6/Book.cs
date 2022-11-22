using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

///////////////////////////////////////////////////////////////////////////////
//
// Author: Blaine Anderson, Andersonjb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 6
// Description: Project demonstrating understanding of AVLTrees
//
///////////////////////////////////////////////////////////////////////////////

namespace Anderson_Project6
{
    /// <summary>
    /// Represents a Book and has properties Key, Title, Author, Pages, and publisher.
    /// Implements the IComparable interface to compare books with each other based on their keys.
    /// </summary>
    internal class Book : IComparable<Book>
    {
        #region Properties

        /// <summary>
        /// string to change what the tree is sorted by
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// string value to represent the title of the book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// string value to represent the author of the book
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// int value to represent the number of pages the book has
        /// </summary>
        public int Pages { get; set; }
        /// <summary>
        /// string value to represent the publisher of the book
        /// </summary>
        public string Publisher { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor used to instantiate a blank book 
        /// for later use
        /// </summary>
        public Book()
        {

        }

        /// <summary>
        /// Constructor to instantiate a new book with the values of the book passed as parameters
        /// </summary>
        /// <param name="title"> string value that titles of books are passed into </param>
        /// <param name="author"> string value that authors of books are passed into </param>
        /// <param name="pages"> int value for number of pages in the book </param>
        /// <param name="publisher"> string value for the publisher of the book </param>
        public Book(string title, string author, int pages, string publisher)
        {
            this.Title = title;
            this.Author = author;
            this.Pages = pages;
            this.Publisher = publisher;
        }

        #endregion

        #region Print()

        /// <summary>
        /// displays the title, author, number of pages, and publisher of the book
        /// with the title highlighted in red
        /// </summary>
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Title: " + Title);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Author: " + Author + "\n"
                             + "Pages: " + Pages + "\n"
                             + "Publisher: " + Publisher + "\n");

        }

        #endregion

        #region CompareTo()

        /// <summary>
        /// Allows books to be compared to each other with their keys
        /// </summary>
        /// <param name="book"> Book object passed into the method to compare </param>
        /// <returns></returns>
        public int CompareTo(Book? book)
        {
            if (Key.CompareTo(book.Key) == 0)       // the book keys are equal
            {
                return 0;
            }
            else if (Key.CompareTo(book.Key) == -1) // the current key is less than the given key
            {
                return -1;
            }
            else return 1;                          // the current key is greater than the given key

        }

        #endregion

        #region SetKey()

        /// <summary>
        ///  Takes user input to pick what the tree is sorted on 
        ///  by changing the key based on the input
        /// </summary>
        /// <param name="input"> Either Title, Author, or Publisher to set what the tree is sorted by </param>
        public void SetKey(string input)
        {
            Dictionary<string, Action> keySetter = new();               // Dispatch table, switch bad
            keySetter["TITLE"] = () => { Key = this.Title; };           // Key is set to Title, Author, or Publisher 
            keySetter["AUTHOR"] = () => { Key = this.Author; };      
            keySetter["PUBLISHER"] = () => { Key = this.Publisher; };

            if (keySetter.ContainsKey(input.ToUpper()))                 // if the input is equal to a key in the dictionary
                keySetter[input.ToUpper()]();                           // go to that key and execute the Action
        }
        #endregion
    }
}
