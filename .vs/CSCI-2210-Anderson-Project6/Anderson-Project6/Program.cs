namespace Anderson_Project6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();

            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);
            tree.Delete(7);
            tree.DisplayTree();
        }
    }
}