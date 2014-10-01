using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using _1DV402.S2.L03C.Properties;

namespace _1DV402.S2.L03C
{
    abstract class Shape3D : Shape
    {
        protected Shape2D _baseShape;
        private double _height;

        public double Height
        {
            get
            { 
                return _height; 
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                _height = value;
            }
        }

        public abstract double MantelArea
        {
            get;
        }

        public abstract double TotalSurfaceArea
        {
            get;
        }

        public abstract double Volume
        {
            get;
        }

        public int CompareTo(object obj){

            if (obj == null) {
                return 2;
            }
            if (obj.GetType().BaseType.Name != "Shape3D")
            {
                throw new ArgumentException();
            }

            Shape3D myShape = (Shape3D)obj;

            if (Volume < myShape.Volume)
            {
                return -1;
            }
            else if (Volume == myShape.Volume)
            {
                return 0;
            }
            else 
            {
                return 1;
            }
        }

        protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height)
            : base(shapeType) {
                _baseShape = baseShape;
                Height = height;
        }

        public override string ToString()
        {
            return String.Format("{0, -20}: {1, 10:F2} \n{2, -20}: {3, 10:F2}\n{4, -20}: {5, 10:F2}\n{6, -20}: {7, 10:F2}\n{8, -20}: {9, 10:F2}\n{10, -20}: {11, 10:F2}\n", 
                Strings.Length, _baseShape.Length, 
                Strings.Width, _baseShape.Width, 
                Strings.Height, Height, 
                Strings.Volume, Volume, 
                Strings.MantelArea, MantelArea, 
                Strings.TotalSurfaceArea, TotalSurfaceArea);
        }

        public override string ToString(string format)
        {
            if (format == "R")
            {
                return String.Format("{0, -10}{1, 10:F2}{2, 10:F2}{3, 10:F2}{4, 10:F2}{5, 10:F2}{6, 10:F2}", 
                    ShapeType.AsText(), 
                    _baseShape.Length, 
                    _baseShape.Width,
                    Height,
                    MantelArea, 
                    Volume, 
                    TotalSurfaceArea);

            }
            else
            {
                return ToString();
            }

        }
    }
}
