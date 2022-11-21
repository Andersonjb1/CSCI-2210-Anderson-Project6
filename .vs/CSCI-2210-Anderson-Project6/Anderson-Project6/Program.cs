///////////////////////////////////////////////////////////////////////////////
//
// Author: Blaine Anderson, Andersonjb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 6
// Description: Project demonstrating understanding of AVLTrees
//
///////////////////////////////////////////////////////////////////////////////
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.DataStructures;
using System.Linq;

namespace Anderson_Project6
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            #region Set Up
            string file = "C:\\Users\\BLAIN\\OneDrive - East Tennessee State University\\Classes\\Data Structures\\Project 6\\books.csv";
            TextFieldParser parser = new TextFieldParser(file);
            AvlTree<Book> tree = new AvlTree<Book>();

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            List<string[]> data = new List<string[]>();
            int i = 0;

            #endregion

            #region Taking Input

            Console.WriteLine("What would you like to sort by?\n" +
                              "Enter: Title, Author, or Publisher");
            string input = Console.ReadLine();

            #endregion

            #region Adding the CSV data into the AVL Tree
            while (!parser.EndOfData)
            {
                data.Add(parser.ReadFields());
                Book testBook = new(data[i][0], data[i][1], Int32.Parse(data[i][2]), data[i][3]);
                testBook.SetKey(input);
                tree.Add(testBook);
                i++;
            }
            #endregion

            #region Demostrating 
            PrintTree(tree);
            RemoveBook(tree);
            #endregion

        }

        #region PrintTree()
        /// <summary>
        /// Takes an AVL Tree of books as a parameter and uses the Print
        /// method in the Book class to output the contents of the tree.
        /// </summary>
        /// <param name="tree"> The AVL Tree to display </param>
        public static void PrintTree(AvlTree<Book> tree)
        {

            List<Book> treeList = tree.GetInorderEnumerator().ToList(); // using nuget method to output the tree in order to a list

            foreach (Book book in treeList)
            {
                book.Print();
            }
        }
        #endregion

        #region RemoveBook()
        /// <summary>
        /// Removes a book from and rebalances the AVL Tree
        /// </summary>
        /// <param name="tree">AVL Tree to remove the book from</param>
        public static void RemoveBook(AvlTree<Book> tree)
        {
            #region Removing Book

            Console.WriteLine("What book would you like to check out?\n" +
                             $"Enter a book title. \n" +
                             $" EX: {tree.Root.Value.Title}");
            string inputKey = Console.ReadLine();

            List<Book> treeList = tree.GetInorderEnumerator().ToList(); // using nuget method to output the tree in order to a list

            treeList.RemoveAll(books => books.Title == inputKey);       // removing the book specified in the input
            #endregion

            #region Rebalancing Tree

            tree.Clear();                                       //clearing contents of the tree before inserting
            InsertBooks(tree,treeList);                         // using InsertBooks() to build the new tree
            PrintTree(tree);                                    // printing tree to validate removal
            Console.WriteLine($"{inputKey} checked out!");

            #endregion 
        }
        #endregion

        #region InsertBooks()
        /// <summary>
        /// Inserts books into the tree using a given list of books
        /// </summary>
        /// <param name="tree"> AVL Tree of Books to insert into </param>
        /// <param name="books"> List of Books to be inserted into the AVL Tree </param>
        public static void InsertBooks(AvlTree<Book> tree, List<Book> books)
        {
            #region Specifying Key/Adding Books To Tree

            Console.WriteLine("What would you like to sort by?\n" +
                  "Enter: Title, Author, or Publisher");
            string input = Console.ReadLine();

            foreach  (Book book in books)
            {
                book.SetKey(input);
                tree.Add(book); 
            }
            #endregion
        }
        #endregion
    }
}