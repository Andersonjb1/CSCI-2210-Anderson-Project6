using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anderson_Project6
{
        class Node
        {
            public Book data;
            public Node left;
            public Node right;
            public Node(Book data)
            {
                this.data = data;
            }
        }
}
