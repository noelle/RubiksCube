using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{
    public class Cube
    {
        List<Cubie> cubies;

        public Cube()
        {
            this.cubies = new List<Cubie>();

            Cubie cubie1 = new Cubie(CubieType.Corner, 1, -1, 1, CubieColor.Y, CubieColor.B, CubieColor.O);
            Cubie cubie2 = new Cubie(CubieType.Edge, 1, 0, 1, CubieColor.R, CubieColor.None, CubieColor.W);
            Cubie cubie3 = new Cubie(CubieType.Corner, 1, 1, 1, CubieColor.O, CubieColor.W, CubieColor.B);
            Cubie cubie4 = new Cubie(CubieType.Edge, 1, -1, 0, CubieColor.G, CubieColor.R, CubieColor.None);
            Cubie cubie5 = new Cubie(CubieType.Center, 1, 0, 0, CubieColor.Y, CubieColor.None, CubieColor.None);
            Cubie cubie6 = new Cubie(CubieType.Edge, 1, 1, 0, CubieColor.Y, CubieColor.B, CubieColor.None);


        }

        public void rotateFront(Direction direction)
        {
            rotate(1, Axis.X, direction);
            changeColor();
        }

        public void rotateBack(Direction direction)
        {
            rotate(-1, Axis.X, direction);
        }

        public void rotate(int coordinate, Axis axis, Direction direction)
        {
            //implement
            getCubies(coordinate, axis);

        }


        public void changeColor()
        {
            //implement, Parameter noch setzen
        }

        public List<Cubie> getCubies(int coordinate, Axis axis)
        {
            return null;
        }
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }

    public enum Direction
    {
        Left,
        Right
    }
}
