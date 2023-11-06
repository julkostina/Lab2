using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Vector : IComparable<Vector>, IComparable
{
    public string color { get; private set; }
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
    public double Length { get { return Math.Sqrt(Math.Pow(end.x, 2) + Math.Pow(end.y, 2)); } private set { } }
    public void IncreaseBy(int num)
    {
        this.end.y = Math.Sqrt(Math.Pow(Length + num,2) - Math.Pow(this.end.x,2));
    }
    public override string ToString()
    {
        return $"Points: (0;0)  ({this.end.x};{Math.Round(this.end.y, 3)}) Length: {Math.Round(this.Length, 3)} Color: {this.color}";
    }

    public int CompareTo(Vector? other)
    {
        return Length.CompareTo(other?.Length);
    }

    public int CompareTo(object? obj)
    {
        Vector vec = (Vector)obj;
        return Length.CompareTo(vec?.Length);
    }
}

