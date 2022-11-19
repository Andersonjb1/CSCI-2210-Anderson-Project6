using Microsoft.VisualBasic.FileIO;

namespace Anderson_Project6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\BLAIN\\OneDrive - East Tennessee State University\\Classes\\Data Structures\\Project 6\\books.csv";
            TextFieldParser parser = new TextFieldParser(file);
            AVLTree library = new AVLTree();

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            List<string[]> data = new List<string[]>();
            int index = 0;

            while (!parser.EndOfData)
            {

                data.Add(parser.ReadFields());
                for (int i = 0; i < data.Count(); i++)
                {
                    Book testBook = new(data[i][0], data[i][1], Int32.Parse(data[i][2]), data[i][3]);
                    library.CheckIn(testBook);

                    //testBook.Title = data[i][0];
                    //testBook.Author = data[i][1];
                    //testBook.Pages = Int32.Parse(data[i][2]);
                    //testBook.Publisher = data[i][3];
                    //library.CheckIn(testBook);
                }


            }
            library.DisplayTree();
            library.Find("20000 Leagues Under the Sea");
            library.CheckOut("20000 Leagues Under the Sea");
        }
    }
}