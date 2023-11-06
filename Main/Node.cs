using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Node<T>: IComparable<Node<T>> where T : IComparable<T>
    {
        public T Data { get;  set; }
        public Node<T> Left { get;  set; }
        public Node<T> Right { get;  set; }
        public Node(T value)
        {
            Data = value;
        }
        public int CompareTo(Node<T> other)
        {
            if (other == null)
                return 1;
            return Data.CompareTo(other.Data);
        }

    }
}
