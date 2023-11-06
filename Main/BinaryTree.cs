using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class BinaryTree<T>:IEnumerable<T> where T : IComparable<T>
    {
        public Node<T>? Root { get; private set; }
        public BinaryTree()
        {
            Root=null;
        }
        public void Add(T data)
        {
            Root = Insert(Root, data);
        }
        private Node<T> Insert(Node<T> root, T data)
        {
            if(root== null) 
                return new Node<T>(data);
            int resOfComparison = data.CompareTo(root.Data);
            if(resOfComparison < 0)
            {
                root.Left=Insert(root.Left, data);
            }
               
            if (resOfComparison > 0)
            {
                root.Right = Insert(root.Right, data);
            }
            return root;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(Root);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Enumerator<T>:IEnumerator<T> where T : IComparable<T>
    {
        private Node<T>? root;
        private Node<T>? current;
        bool moved = false;
        public Enumerator(Node<T>? node)
        {
            root = node;
        }
        public T Current => current.Data;
        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            if (root == null)
            {
                return false;
            }

            if (!moved)
            {
                current = findLastLeft(root);
                moved = true;
                return current != null;
            }

            if (current?.Right != null)
            {
                current = findLastLeft(current.Right);
                return current != null;
            }

            while (current != null)
            {
                Node<T>? parent = findParentNode(root, current);

                if (parent == null)
                {
                    current = null;
                    return false;
                }

                if (parent.Left == current)
                {
                    current = parent;
                    return true;
                }

                current = parent;
            }

            return false;
        }
        public void Reset()
        {
            current = null;
            moved = false;
        }
        public void Dispose() { }
        private Node<T> findLastLeft(Node<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
        private Node<T>? findParentNode(Node<T>? root, Node<T> node)
        {
            if (node == root || root == null)
                return null;
            if (root.Right == node || root.Left == node)
                return root;
            if ((root.Data.CompareTo(root.Data) < 0))
                return findParentNode(root?.Left, node);
            else
                return findParentNode(root?.Right, node);
        }
    }
}
