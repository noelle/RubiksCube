using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using RubiksCube.Model;

namespace RubiksGUI
{
    public static class Helper
    {
        public static SolidColorBrush getBrush(CubieColor color)
        {
            switch (color)
            {
                case CubieColor.B:
                    return Brushes.Blue;
                case CubieColor.G:
                    return Brushes.Green;
                case CubieColor.O:
                    return Brushes.Orange;
                case CubieColor.R:
                    return Brushes.Red;
                case CubieColor.W:
                    return Brushes.White;
                case CubieColor.Y:
                    return Brushes.Yellow;
                default:
                    return null;
            }
        }

        public static CubieColor getColor(SolidColorBrush brush)
        {
            if (brush == Brushes.Blue)
            {
                return CubieColor.B;
            }
            if (brush == Brushes.Green)
            {
                return CubieColor.G;
            }
            if (brush == Brushes.Orange)
            {
                return CubieColor.O;
            }
            if (brush == Brushes.Red)
            {
                return CubieColor.R;
            }
            if (brush == Brushes.White)
            {
                return CubieColor.W;
            }
            if (brush == Brushes.Yellow)
            {
                return CubieColor.Y;
            }
            else
            {
                return CubieColor.None;
            }
        }
    }
}
