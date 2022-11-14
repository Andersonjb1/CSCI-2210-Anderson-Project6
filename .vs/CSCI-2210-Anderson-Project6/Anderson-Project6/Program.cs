namespace Anderson_Project6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String filepath = "C:\\Users\\BLAIN\\OneDrive - East Tennessee State University\\Classes\\Data Structures\\Project 6\\books.csv";

            StreamReader reader = new StreamReader(filepath);
            List<string> lineList = new();
            List<string> wordList = new();
            Book book = new();

            while(!reader.EndOfStream)
            {
                lineList.Add(reader.ReadLine());
            }
            for (int i = 0; i < lineList.Count; i++)
            {
                book.Title = lineList[i].Split(",");
                lineList[i + 1].Split(",");
                lineList[i + 2].Split(",");
                lineList[i + 3].Split(",");
                lineList[i + 4].Split(",");  
                Console.WriteLine(wordList[35]);
            }
            //Book book = new Book(reader.ReadLine);
            //book.Print();
        }
    }
}