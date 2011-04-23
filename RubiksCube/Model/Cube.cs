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

            Cubie frontCubie1 = new Cubie(CubieType.Corner, 1, -1, 1, CubieColor.Y, CubieColor.B, CubieColor.O);
            Cubie frontCubie2 = new Cubie(CubieType.Edge, 1, 0, 1, CubieColor.R, CubieColor.None, CubieColor.W);
            Cubie frontCubie3 = new Cubie(CubieType.Corner, 1, 1, 1, CubieColor.O, CubieColor.W, CubieColor.B);
            Cubie frontCubie4 = new Cubie(CubieType.Edge, 1, -1, 0, CubieColor.G, CubieColor.R, CubieColor.None);
            Cubie frontCubie5 = new Cubie(CubieType.Center, 1, 0, 0, CubieColor.Y, CubieColor.None, CubieColor.None);
            Cubie frontCubie6 = new Cubie(CubieType.Edge, 1, 1, 0, CubieColor.Y, CubieColor.B, CubieColor.None);
            Cubie frontCubie7 = new Cubie(CubieType.Corner, 1, -1, -1, CubieColor.G, CubieColor.O, CubieColor.Y);
            Cubie frontCubie8 = new Cubie(CubieType.Edge, 1, 0, -1, CubieColor.O, CubieColor.None, CubieColor.B);
            Cubie frontCubie9 = new Cubie(CubieType.Corner, 1, 1, -1, CubieColor.W, CubieColor.G, CubieColor.O);

            Cubie backCubie1 = new Cubie(CubieType.Corner, -1, -1, -1, CubieColor.Y, CubieColor.O, CubieColor.G);
            Cubie backCubie2 = new Cubie(CubieType.Edge, -1, 0, -1, CubieColor.B, CubieColor.None, CubieColor.O);
            Cubie backCubie3 = new Cubie(CubieType.Corner, -1, 1, -1, CubieColor.O, CubieColor.G, CubieColor.W);
            Cubie backCubie4 = new Cubie(CubieType.Corner, -1, -1, 0, CubieColor.W, CubieColor.O, CubieColor.None);
            Cubie backCubie5 = new Cubie(CubieType.Center, -1, 0, 0, CubieColor.B, CubieColor.None, CubieColor.None);
            Cubie backCubie6 = new Cubie(CubieType.Edge, -1, 1, 0, CubieColor.Y, CubieColor.R, CubieColor.None);
            Cubie backCubie7 = new Cubie(CubieType.Corner, -1, -1, 1, CubieColor.G, CubieColor.Y, CubieColor.R);
            Cubie backCubie8 = new Cubie(CubieType.Edge, -1, 0, 1, CubieColor.O, CubieColor.None, CubieColor.Y);
            Cubie backCubie9 = new Cubie(CubieType.Corner, -1, 1, 1, CubieColor.G, CubieColor.W, CubieColor.R);

            Cubie middleCubie1 = new Cubie(CubieType.Edge, 0, -1, 1, CubieColor.None, CubieColor.B, CubieColor.W);
            Cubie middleCubie2 = new Cubie(CubieType.Center, 0, 0, 1, CubieColor.None, CubieColor.None, CubieColor.W);
            Cubie middleCubie3 = new Cubie(CubieType.Edge, 0, 1, 1, CubieColor.None, CubieColor.O, CubieColor.G);
            Cubie middleCubie4 = new Cubie(CubieType.Center, 0, 1, 0, CubieColor.None, CubieColor.R, CubieColor.None);
            Cubie middleCubie5 = new Cubie(CubieType.Edge, 0, 1, -1, CubieColor.None, CubieColor.B, CubieColor.Y);
            Cubie middleCubie6 = new Cubie(CubieType.Center, 0, 0, -1, CubieColor.None, CubieColor.None, CubieColor.Y);
            Cubie middleCubie7 = new Cubie(CubieType.Edge, 0, -1, -1, CubieColor.None, CubieColor.R, CubieColor.G);
            Cubie middleCubie8 = new Cubie(CubieType.Center, 0, -1, 0, CubieColor.None, CubieColor.O, CubieColor.None);

            this.cubies.Add(frontCubie1);
            this.cubies.Add(frontCubie2);
            this.cubies.Add(frontCubie3);
            this.cubies.Add(frontCubie4);
            this.cubies.Add(frontCubie5);
            this.cubies.Add(frontCubie6);
            this.cubies.Add(frontCubie7);
            this.cubies.Add(frontCubie8);
            this.cubies.Add(frontCubie9);

            this.cubies.Add(backCubie1);
            this.cubies.Add(backCubie2);
            this.cubies.Add(backCubie3);
            this.cubies.Add(backCubie4);
            this.cubies.Add(backCubie5);
            this.cubies.Add(backCubie6);
            this.cubies.Add(backCubie7);
            this.cubies.Add(backCubie8);
            this.cubies.Add(backCubie9);

            this.cubies.Add(middleCubie1);
            this.cubies.Add(middleCubie2);
            this.cubies.Add(middleCubie3);
            this.cubies.Add(middleCubie4);
            this.cubies.Add(middleCubie5);
            this.cubies.Add(middleCubie6);
            this.cubies.Add(middleCubie7);
            this.cubies.Add(middleCubie8);
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

        public void drawInConsole()
        {
            System.Console.WriteLine("Hallo Cube!");
            List<Cubie> topCubies = this.cubies.Where(q => q.PosZ == 1).OrderBy(q=>q.PosX).ThenBy(q=> q.PosY).ToList();
            System.Console.WriteLine();
            System.Console.WriteLine("TOP of the Cube");
            System.Console.WriteLine();
            System.Console.WriteLine("   {0}{1}{2}   ", topCubies.ElementAt(0), topCubies.ElementAt(1), topCubies.ElementAt(3));
            System.Console.WriteLine("   {0}{1}{2}   ", topCubies.ElementAt(4), topCubies.ElementAt(5), topCubies.ElementAt(6));
            System.Console.WriteLine("   {0}{1}{2}   ", topCubies.ElementAt(7), topCubies.ElementAt(8), topCubies.ElementAt(9));
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
