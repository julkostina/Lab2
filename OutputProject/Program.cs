using Main;
using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace OutputProject
{
    public class ConsoleMenu
    {
        static public void PreOrder<T>(Node<T>? current) where T : IComparable<T> 
        {
            Console.WriteLine(current.Data);
            if (current.Left != null)
            {
                PreOrder(current.Left);
            }
            if (current.Right != null)
            {
                PreOrder(current.Right);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Generic list:");
            List<Vector> genericVectors = new List<Vector>();
            genericVectors.Add(new Vector("blue", 2, 2));
            genericVectors.Add(new Vector("green", 4, 4));
            genericVectors.Add(new Vector("red", 4, 2));
            genericVectors.Add(new Vector("white", 3, 3));
            genericVectors.RemoveAt(2);
            genericVectors[0].IncreaseBy(2);
            genericVectors.Sort();
            foreach (Vector vector in genericVectors)
            {
                Console.WriteLine(vector);
            }
            Console.WriteLine($"Vector with points (0;0) (3;3) found  on {genericVectors.FindIndex(s=>s.color=="white")} position\n");

            

            Console.WriteLine("Non-generic list:");
            ArrayList list = new ArrayList();
            list.Add(new Vector("black", 1, 2));
            list.Add(new Vector("yellow", 4, 4));
            list.Add(new Vector("pink", 4, 2));
            list.Add(new Vector("violet", 5,5));
            list.RemoveAt(2);
            list.OfType<Vector>().Last<Vector>().IncreaseBy(2);
            list.Sort();
            foreach (Vector vector in list)
            {
                Console.WriteLine(vector);
            }
            Console.WriteLine($"Vector with points (0;0) (4;4) found  on {list.IndexOf(list.OfType<Vector>().FirstOrDefault(s => s.color == "yellow"))} position\n");


            Console.WriteLine("Array:");
            Vector[] array = new Vector[4];
            array[0] = new Vector("grey", 0, 1);
            array[1] = new Vector("green", 2, 1);
            array[2] = new Vector("golden", 0, 3);
            array[3] = new Vector("silver", 5, 5);
            array[1] = null;
            array[0].IncreaseBy(2);
            Array.Sort(array);
            foreach (Vector vec in array)
            {
                if (vec != null)
                    Console.WriteLine(vec);
            }
            Console.WriteLine($"Vector with points (0;0) (5;5) was found on {Array.IndexOf(array,Array.Find(array, i => i != null && i.color == "silver"))} position\n");


            BinaryTree<Vector> tree = new BinaryTree<Vector>();
            tree.Add(new Vector("blue", 1, 1));
            tree.Add(new Vector("red", 2, 3));
            tree.Add(new Vector("brown", 1, 3));
            Console.WriteLine("Binary tree:");
            foreach (Vector vec in tree)
            {
                if (vec != null)
                {
                    Console.WriteLine(vec);
                }
            }
            Console.WriteLine("\nPreorder traversal order:");
            PreOrder(tree.Root);

        }
    }
        
           
}
