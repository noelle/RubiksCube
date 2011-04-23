using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{
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

    public enum CubeSurface
    {
        Top,
        Front,
        Left,
        Right,
        Bottom,
        Back
    }

    public class Cube
    {
        List<Cubie> cubies;

        public Cube()
        {
            this.cubies = new List<Cubie>();

            // build the cube
            this.createCube();
        }

        /// <summary>
        /// Creates a test cube
        /// </summary>
        private void createCube()
        {
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

        /// <summary>
        /// Rotates the front of the cube to a definded direction
        /// (left or right)
        /// </summary>
        /// <param name="direction"> direction which is to be rotated in</param>
        public void rotateFront(Direction direction)
        {
            this.rotate(CubeSurface.Front, direction);
            //changeColor();
        }

        /// <summary>
        /// Rotates the back of the cube to a defined direction
        /// (left or right)
        /// </summary>
        /// <param name="direction">direction which is to be rotaded in</param>
        public void rotateBack(Direction direction)
        {
            //rotate(-1, Axis.X, direction);
        }

        private void rotate(CubeSurface cubeSurface, Direction direction)
        {
            // get the cubies of the wished cube surface
            List<Cubie> cubies = this.getCubeSurface(cubeSurface);
            int tempPos;

            switch (direction)
            {
                case Direction.Left:
                    foreach (Cubie cubie in cubies)
                    {
                        tempPos = cubie.PosY;
                        cubie.PosY = cubie.PosZ * -1;
                        cubie.PosZ = tempPos;
                    }
                    break;

                case Direction.Right:
                    foreach (Cubie cubie in cubies)
                    {
                        tempPos = cubie.PosY;
                        cubie.PosY = cubie.PosZ;
                        cubie.PosZ = tempPos * -1;
                    }
                    break;
                    
                default:
                    break;
            }
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

        /// <summary>
        /// Returns a list of all of the cubies of a cube surface
        /// </summary>
        /// <param name="surface">the cube surface</param>
        /// <returns>List of the cubies of the cube surface</returns>
        private List<Cubie> getCubeSurface(CubeSurface surface)
        {
            List<Cubie> cubies;

            switch (surface)
            {
                case CubeSurface.Front:
                    cubies = this.cubies.Where(q => q.PosX == 1).ToList();
                    break;

                case CubeSurface.Back:
                    cubies = this.cubies.Where(q => q.PosX == -1).ToList();
                    break;

                case CubeSurface.Left:
                    cubies = this.cubies.Where(q => q.PosY == -1).ToList();
                    break;

                case CubeSurface.Right:
                    cubies = this.cubies.Where(q => q.PosY == 1).ToList();
                    break;

                case CubeSurface.Top:
                    cubies = this.cubies.Where(q => q.PosZ == 1).ToList();
                    break;

                case CubeSurface.Bottom:
                    cubies = this.cubies.Where(q => q.PosZ == -1).ToList();
                    break;

                default:
                    cubies = null;
                    break;
            }
            
            return cubies;
        }
    }
}
