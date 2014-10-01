using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L03C
{
    class Cuboid : Shape3D
    {
        public override double MantelArea
        {
            get {
                return _baseShape.Perimeter * Height;
            }
        }

        public override double TotalSurfaceArea
        {
            get
            {
                return MantelArea + 2 * _baseShape.Area;
            }
        }

        public override double Volume
        {
            get
            {
                return _baseShape.Area * Height;
            }
        }

        public Cuboid(double lenght, double width, double height)
            : base(ShapeType.Cuboid, new Rectangle(lenght, width), height) { 
        
        }
    }
}
