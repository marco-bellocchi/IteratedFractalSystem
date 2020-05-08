using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalLibrary.Helpers
{
    public static class FractionHelper
    {
        public static float FractionToDouble(string fraction)
        {
            double result;

            if (double.TryParse(fraction, out result))
            {
                return (float)result;
            }

            string[] split = fraction.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (split.Length == 2)
                    {
                        return (float)a / (float)b;
                    }

                    int c;

                    if (int.TryParse(split[2], out c))
                    {
                        return a + (float)b / (float)c;
                    }
                }
            }

            throw new FormatException("Not a valid fraction.");
        }
    }
}
