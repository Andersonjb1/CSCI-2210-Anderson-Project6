namespace Anderson_Project6
{
    internal class AVLTree
    {
        Node root;
        public AVLTree()
        {
        }

        public void CheckIn(Book data)
        {
            Node newItem = new Node(data);   
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }
        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Value.Title.CompareTo(current.Value.Title) < 0)
            {
                current.Left = RecursiveInsert(current.Left, n);
                current = BalanceTree(current);
            }
            else if (n.Value.Title.CompareTo(current.Value.Title) > 0)
            {
                current.Right = RecursiveInsert(current.Right, n);
                current = BalanceTree(current);
            }
            return current;
        }
        //MAY BREAK HERE
        private Node BalanceTree(Node current)
        {
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        public void CheckOut(string title)
        {//and here
            root = CheckOut(root, title);
            Console.WriteLine($"{title} checked out!");
            Console.WriteLine("#############################");
            DisplayTree();
        }
        private Node CheckOut(Node current, string target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                //Left subtree
                if (current.Value.Title.CompareTo(target) < 0)
                {
                    current.Left = CheckOut(current.Left, target);
                    if (BalanceFactor(current) == -2)//here
                    {
                        if (BalanceFactor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //Right subtree
                else if (current.Value.Title.CompareTo(target) > 0)
                {
                    current.Right = CheckOut(current.Right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.Right != null)
                    {
                        //delete its inorder successor
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Value = parent.Value;
                        current.Right = CheckOut(current.Right, target);
                        if (BalanceFactor(current) == 2)//rebalancing
                        {
                            if (BalanceFactor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.Left != null
                        return current.Left;
                    }
                }
            }
            return current;
        }

        public void Find(string key)
        {
            if (Find(key, root).Value.Title == key)
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }

        private Node Find(string input, Node current)
        {

            if (input.CompareTo(current.Value.Title) < 0)
            {
                if (input == current.Value.Title)
                {
                    return current;
                }
                else
                    return Find(input, current.Left);
            }
            else
            {
                if (input == current.Value.Title)
                {
                    return current;
                }
                else
                    return Find(input, current.Right);
            }

        }
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.Left);
                current.Value.Print();
                InOrderDisplayTree(current.Right);
            }
        }
        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int GetHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = GetHeight(current.Left);
                int r = GetHeight(current.Right);
                int m = Max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int BalanceFactor(Node current)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int bFactor = l - r;
            return bFactor;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}
