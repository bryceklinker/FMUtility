using System.Drawing;
using FMUtility.Models;

namespace FMUtility.Data.Extensions
{
    public static class ColorExtensions
    {
        public static ColorModel AsColorModel(this Color color)
        {
            return new ColorModel
            {
                A = color.A,
                B = color.B,
                G = color.G,
                R = color.R
            };
        }
    }
}