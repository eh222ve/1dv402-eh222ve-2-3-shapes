using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L03C
{
    class Ellipse : Shape2D
    {
        public override double Area{
            get {
                return Math.PI * Length * Width;
            }
        }

        public override double Perimeter
        {
            get
            {
                return Math.PI * Math.Sqrt(2 * Math.Exp(Length) + 2 * Math.Exp(Width));
            }
        }

        public Ellipse(double radius)
            : base(ShapeType.Circle, radius, radius)
        {
        }

        public Ellipse(double hradius, double vradius)
            : base(ShapeType.Ellipse, hradius, vradius)
        {
        }

    }
}
