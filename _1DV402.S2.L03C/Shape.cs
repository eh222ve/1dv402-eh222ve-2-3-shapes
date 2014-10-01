using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L03C
{
    abstract class Shape
    {
        public bool IsShape3d
        {
            get{
                switch(ShapeType){
                    case ShapeType.Cuboid:
                    case ShapeType.Cylinder:
                    case ShapeType.Sphere:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public ShapeType ShapeType
        {
            get;
            private set;
        }

        protected Shape(ShapeType shapeType) {
            ShapeType = shapeType;
        }

        public abstract string ToString(string format);
    }

    public enum ShapeType
    {
        Rectangle,
        Circle,
        Ellipse,
        Cuboid,
        Cylinder,
        Sphere
    };
}
