using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{
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

        public HistoryItem(Cube cube, int order, string moveTextual)
        {
            this.cube = cube;
            this.order = order;
            this.moveTextual = moveTextual;
        }
    }
}
