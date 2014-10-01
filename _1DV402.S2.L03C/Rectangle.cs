using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L03C
{
    class Rectangle : Shape2D
    {
        public override double Area{
            get {
                return this.Width * this.Length;
            }
        }

        public override double Perimeter
        {
            get
            {
                return (this.Width * 2) + (this.Length * 2);
            }
        }

        public Rectangle(double length, double width) 
        : base(ShapeType.Rectangle, length, width){
        }
    }
}
