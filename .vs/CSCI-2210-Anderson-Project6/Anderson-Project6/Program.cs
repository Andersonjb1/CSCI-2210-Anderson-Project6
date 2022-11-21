using Microsoft.VisualBasic.FileIO;
using System.Collections;
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

            while (!parser.EndOfData)
            {
                data.Add(parser.ReadFields());
                Book testBook = new(data[i][0], data[i][1], Int32.Parse(data[i][2]), data[i][3]);
                tree.Add(testBook);
                i++;
            }
            #endregion

            List<Book> testIO = tree.GetInorderEnumerator().ToList();

            foreach (Book book in testIO)
            {
                book.Print();
            }
        }
    }
}