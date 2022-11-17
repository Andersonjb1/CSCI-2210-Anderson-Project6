namespace Anderson_Project6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            Book book = new Book("aba","bab", 32, "aab");
            Book bookie= new Book("tit", "vag", 69, "po");
            Book zzzzz = new Book("z", "a", 1000, "ooo");
            Book test = new Book(" ", "dd", 0, "");
            Book test2 = new Book(" ", "22", 1, "");
            tree.Add(zzzzz);
            tree.Add(book);
            tree.Add(bookie);
            tree.Find(zzzzz);
            tree.Delete(zzzzz);
            tree.Delete(book);
            tree.DisplayTree();
            //Git is not working properly
        }
    }
}