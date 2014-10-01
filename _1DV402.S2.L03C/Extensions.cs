using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DV402.S2.L03C;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public static string AsText(this ShapeType shapeType) {
            return shapeType.ToString();
        }

        public static string CenterAlignString(this string s, string other, int maxWidth = 60) {

            string output;

            int width = maxWidth;
            int stringLength = s.Length;

            int toCenter = (width - stringLength) / 2;

            output = other;

            for (int left = 1; left < toCenter; left++) {
                output += " ";
            }

            output += s;

            if (stringLength % 2 != 0) {
                toCenter++;
            }

            for (int right = 1; right < toCenter; right++) {
                output += " ";
            }
            output += other;

            return output;

        }

    }
}
