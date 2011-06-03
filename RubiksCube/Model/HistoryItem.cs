using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{
    public static class ImageLocation
    {
        //public static string BackLeft = "/RubiksGUI;component/Images/BackLeft.png";
        //public static string BackRight = "/RubiksGUI;component/Images/BackRight.png";
        //public static string BottomLeft = "/RubiksGUI;component/Images/BottomLeft.png";
        //public static string BottomRight = "/RubiksGUI;component/Images/BottomRight.png";
        //public static string FrontLeft = "/RubiksGUI;component/Images/FrontLeft.png";
        //public static string FrontRight = "/RubiksGUI;component/Images/FrontRight.png";
        //public static string LeftLeft = "/RubiksGUI;component/Images/LeftLeft.png";
        //public static string LeftRight = "/RubiksGUI;component/Images/LeftRight.png";
        //public static string RightLeft = "/RubiksGUI;component/Images/RightLeft.png";
        //public static string RightRight = "/RubiksGUI;component/Images/RightRight.png";
        //public static string TopLeft = "/RubiksGUI;component/Images/TopLeft.png";
        //public static string TopRight = "/RubiksGUI;component/Images/TopRight.png";

        public static string Circular180 = "/RubiksGUI;component/Images/Circular180.png";
        public static string CircularLeft90 = "/RubiksGUI;component/Images/CircularLeft90.png";
        public static string CircularRight90 = "/RubiksGUI;component/Images/CircularRight90.png";

        public static string Horizontal180 = "/RubiksGUI;component/Images/Horizontal180.png";
        public static string HorizontalLeft90 = "/RubiksGUI;component/Images/HorizontalLeft90.png";
        public static string HorizontalRight90 = "/RubiksGUI;component/Images/HorizontalRight90.png";

        public static string Vertical180 = "/RubiksGUI;component/Images/Vertical180.png";
        public static string VerticalLeft90 = "/RubiksGUI;component/Images/VerticalLeft90.png";
        public static string VerticalRight90 = "/RubiksGUI;component/Images/VerticalRight90.png";


    }
    public class HistoryItem
    {
        private Cube cube;

        public Cube Cube
        {
            get { return cube; }
            set { cube = value; }
        }

        private int order;

        public int Order
        {
            get { return order; }
            //set { order = value; }
        }

        private string moveTextual;

        public string MoveTextual
        {
            get { return String.Format("{0}. {1}", order.ToString(), moveTextual); }
            //set { moveTextual = value; }
        }

        public string imageLocation;

        public string ImageLocation
        {
            get { return this.imageLocation; }
        }

        public HistoryItem(Cube cube, int order, string moveTextual, string imageLocation)
        {
            this.cube = cube;
            this.order = order;
            this.moveTextual = moveTextual;
            this.imageLocation = imageLocation;
        }
    }
}
