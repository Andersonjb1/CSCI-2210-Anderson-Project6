using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.DataStructures;
using System.Linq;

namespace Anderson_Project6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Adding Books To Tree
            string file = "C:\\Users\\BLAIN\\OneDrive - East Tennessee State University\\Classes\\Data Structures\\Project 6\\books.csv";
            TextFieldParser parser = new TextFieldParser(file);
            AvlTree<Book> tree = new AvlTree<Book>();

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            List<string[]> data = new List<string[]>();
            int i = 0;

            Console.WriteLine("What would you like to sort by?");
            string input = Console.ReadLine();

            while (!parser.EndOfData)
            {
                data.Add(parser.ReadFields());
                Book testBook = new(data[i][0], data[i][1], Int32.Parse(data[i][2]), data[i][3]);
                testBook.SetKey(input);
                tree.Add(testBook);
                i++;
            }
            #endregion


            PrintTree(tree);
            RemoveBook(tree);
            Console.WriteLine(tree.Any(book => book.Title == "Angels & Demons"));
            PrintTree(tree);


        }

        public static void PrintTree(AvlTree<Book> tree)
        {
            List<Book> treeList = tree.GetInorderEnumerator().ToList();

            foreach (Book book in treeList)
            {
                book.Print();
            }
        }

        public static void RemoveBook(AvlTree<Book> tree)
        {
            Console.WriteLine("What book would you like to remove?\n" + "Enter a Title");
            string inputTitle = Console.ReadLine();

            if (tree.Root.Value.Title == inputTitle)
            {
                tree.Where(book => book.Title == inputTitle).Equals(null);
            }
            else RemoveBook(tree);
            //try node
        }
    }
}