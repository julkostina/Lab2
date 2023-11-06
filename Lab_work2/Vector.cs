using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_work2
{
    public class Vector
    {
        string color;
        class Point
        {
            public double x, y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }   
        }
        Point end;
        public Vector(string color, int x1, int y1)
        {
            this.color = color;
            this.end = new Point(x1, y1);
        }
        public double Length()
        {
            return Math.Sqrt(Math.Pow(end.x, 2) + Math.Pow(end.y, 2));
        }
        public void IncreaseBy(int num)
        {
            this.end.y=Math.Sqrt(Math.Sqrt(Length() + num)-this.end.x);
        }
        public override string ToString()
        {
            return $"Points: (0;0)  ({this.end.x};{this.end.y})\nLength: {this.Length}";
        }
    }
}
