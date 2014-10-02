using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using _1DV402.S2.L03C.Properties;

namespace _1DV402.S2.L03C
{
    abstract class Shape2D : Shape
    {
        private double _length;
        private double _width;

        public abstract double Area
        {
            get;
        }
        public double Length
        {
            get {
                return _length;
            }
            set {
                if (value <= 0) {
                    throw new ArgumentException();
                }
                _length = value;
            }
        }

        public abstract double Perimeter
        {
            get;
        }

        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                _width = value;
            }
        }

        public int CompareTo(object obj)
        {

            if (obj == null)
            {
                return 2;
            }
            if (obj.GetType().BaseType.Name != "Shape2D")
            {
                throw new ArgumentException();
            }

            Shape2D myShape = (Shape2D)obj;

            if (Area < myShape.Area)
            {
                return -1;
            }
            else if (Area == myShape.Area) 
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public Shape2D(ShapeType shapeType, double length, double width)
            : base(shapeType)
        {
            Length = length;
            Width = width;
        }

        public override string ToString()
        {
            return String.Format("{0, -15}: {1, 10:F2} \n{2, -15}: {3, 10:F2}\n{4, -15}: {5, 10:F2}\n{6, -15}: {7, 10:F2}", Strings.Length, Length, Strings.Width, Width, Strings.Area, Area, Strings.Perimeter, Perimeter);
        }

        public override string ToString(string format)
        {
            if (format == "R")
            {
                return String.Format("{0, -10}{1, 10:F0}{2, 10:F0}{3, 10:F0}{4, 10:F0}", ShapeType.AsText(), Length, Width, Area, Perimeter);

            }
            else {
                return ToString();
            }

        }
    }
}
