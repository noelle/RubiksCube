using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{
    public class Cube
    {
        public Cube()
        {

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

        }


        public void changeColor()
        {
            //implement, Parameter noch setzen
        }

        public void drawInConsole()
        {
            System.Console.WriteLine("Hallo Cube!");
            //List<Cubie> topCubies = this.c
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
