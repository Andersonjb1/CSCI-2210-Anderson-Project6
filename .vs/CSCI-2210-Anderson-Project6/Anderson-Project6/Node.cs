using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anderson_Project6
{
    class Node
    {
        public Book Value;
        public Node Left;
        public Node Right;
        public Node Parent;
        public Node(Book data)
        {
            this.Value = data;
        }
    }
}
