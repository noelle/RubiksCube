using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.Model
{

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
        Back,
        Middle
    }

    public class Cube
    {
        List<Cubie> cubies;

        public List<Cubie> Cubies
        {
            get { return cubies; }
            set { cubies = value; }
        }

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
            Cubie frontCubie4 = new Cubie(CubieType.Edge, 1, -1, 0, CubieColor.G, CubieColor.Y, CubieColor.None);
            Cubie frontCubie5 = new Cubie(CubieType.Center, 1, 0, 0, CubieColor.G, CubieColor.None, CubieColor.None);
            Cubie frontCubie6 = new Cubie(CubieType.Edge, 1, 1, 0, CubieColor.R, CubieColor.B, CubieColor.None);
            Cubie frontCubie7 = new Cubie(CubieType.Corner, 1, -1, -1, CubieColor.R, CubieColor.Y, CubieColor.B);
            Cubie frontCubie8 = new Cubie(CubieType.Edge, 1, 0, -1, CubieColor.W, CubieColor.None, CubieColor.G);
            Cubie frontCubie9 = new Cubie(CubieType.Corner, 1, 1, -1, CubieColor.R, CubieColor.W, CubieColor.B);

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
        /// Rotates a cube surface to a wished direction
        /// </summary>
        /// <param name="cubeSurface"></param>
        /// <param name="direction"></param>
        public void rotate(CubeSurface cubeSurface, Direction direction)
        {
            // get the cubies of the wished cube surface
            List<Cubie> cubies = this.getCubeSurface(cubeSurface);
            int tempPos;
            CubieColor tempCol;
            int multX = 1;
            int multY = 1;
            int multZ = 1;

            switch (cubeSurface)
            {
                case CubeSurface.Front:
                    multY = direction == Direction.Left ? -1 : 1;
                    multZ = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosY;
                        cubie.PosY = cubie.PosZ * multY;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColZ;
                        cubie.ColZ = tempCol;
                    }
                    break;

                case CubeSurface.Back:
                    multY = direction == Direction.Right ? -1 : 1;
                    multZ = direction == Direction.Left ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosY;
                        cubie.PosY = cubie.PosZ * multY;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColZ;
                        cubie.ColZ = tempCol;
                    }
                    break;

                case CubeSurface.Top:
                    multX = direction == Direction.Left ? -1 : 1;
                    multY = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosY * multX;
                        cubie.PosY = tempPos * multY;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;

                case CubeSurface.Bottom:
                    multX = direction == Direction.Right ? -1 : 1;
                    multY = direction == Direction.Left ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosY * multX;
                        cubie.PosY = tempPos * multY;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;

                case CubeSurface.Left:
                    multX = direction == Direction.Left ? -1 : 1;
                    multZ = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosZ * multX;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColZ;
                        cubie.ColZ = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;

                case CubeSurface.Right:
                    multX = direction == Direction.Right ? -1 : 1;
                    multZ = direction == Direction.Left ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosZ * multX;
                        cubie.PosZ = tempPos * multZ;

                        // change cubie colors
                        tempCol = cubie.ColZ;
                        cubie.ColZ = cubie.ColX;
                        cubie.ColX = tempCol;
                    }
                    break;
                case CubeSurface.Middle:
                    multX = direction == Direction.Left ? -1 : 1;
                    multY = direction == Direction.Right ? -1 : 1;

                    foreach (Cubie cubie in cubies)
                    {
                        // change cubie coordinates
                        tempPos = cubie.PosX;
                        cubie.PosX = cubie.PosY * multX;
                        cubie.PosY = tempPos * multY;

                        // change cubie colors
                        tempCol = cubie.ColY;
                        cubie.ColY = cubie.ColX;
                        cubie.ColX = tempCol;
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
            System.Console.WriteLine("Rubik's Cube 2D View");
            System.Console.WriteLine();

            // Obere Reihe
            List<CubieColor> topCubies = this.cubies.Where(q => q.PosZ == 1).OrderBy(q => q.PosX).ThenBy(q => q.PosY).Select(q => q.ColZ).ToList();
            System.Console.WriteLine("    {0}{1}{2}   ", topCubies.ElementAt(0), topCubies.ElementAt(1), topCubies.ElementAt(2));
            System.Console.WriteLine("    {0}{1}{2}   ", topCubies.ElementAt(3), topCubies.ElementAt(4), topCubies.ElementAt(5));
            System.Console.WriteLine("    {0}{1}{2}   ", topCubies.ElementAt(6), topCubies.ElementAt(7), topCubies.ElementAt(8));
            System.Console.WriteLine("    ---   ");

            // Mittlere 1. Reihe
            List<CubieColor> midCubies1 = this.cubies.Where(q => q.PosY == -1 && q.PosZ == 1).OrderBy(q => q.PosX).Select(q => q.ColY).ToList();
            midCubies1.AddRange(this.cubies.Where(q => q.PosX == 1 && q.PosZ == 1).OrderBy(q => q.PosY).Select(q => q.ColX).ToList());
            midCubies1.AddRange(this.cubies.Where(q => q.PosY == 1 && q.PosZ == 1).OrderByDescending(q => q.PosX).Select(q => q.ColY).ToList());
            System.Console.WriteLine("{0}{1}{2}|{3}{4}{5}|{6}{7}{8}", midCubies1.ElementAt(0), midCubies1.ElementAt(1), midCubies1.ElementAt(2),
                midCubies1.ElementAt(3), midCubies1.ElementAt(4), midCubies1.ElementAt(5),
                midCubies1.ElementAt(6), midCubies1.ElementAt(7), midCubies1.ElementAt(8));

            // Mittlere 2. Reihe
            List<CubieColor> midCubies2 = this.cubies.Where(q => q.PosY == -1 && q.PosZ == 0).OrderBy(q => q.PosX).Select(q => q.ColY).ToList();
            midCubies2.AddRange(this.cubies.Where(q => q.PosX == 1 && q.PosZ == 0).OrderBy(q => q.PosY).Select(q => q.ColX).ToList());
            midCubies2.AddRange(this.cubies.Where(q => q.PosY == 1 && q.PosZ == 0).OrderByDescending(q => q.PosX).Select(q => q.ColY).ToList());
            System.Console.WriteLine("{0}{1}{2}|{3}{4}{5}|{6}{7}{8}", midCubies2.ElementAt(0), midCubies2.ElementAt(1), midCubies2.ElementAt(2),
                midCubies2.ElementAt(3), midCubies2.ElementAt(4), midCubies2.ElementAt(5),
                midCubies2.ElementAt(6), midCubies2.ElementAt(7), midCubies2.ElementAt(8));

            // Mittlere 3. Reihe
            List<CubieColor> midCubies3 = this.cubies.Where(q => q.PosY == -1 && q.PosZ == -1).OrderBy(q => q.PosX).Select(q => q.ColY).ToList();
            midCubies3.AddRange(this.cubies.Where(q => q.PosX == 1 && q.PosZ == -1).OrderBy(q => q.PosY).Select(q => q.ColX).ToList());
            midCubies3.AddRange(this.cubies.Where(q => q.PosY == 1 && q.PosZ == -1).OrderByDescending(q => q.PosX).Select(q => q.ColY).ToList());
            System.Console.WriteLine("{0}{1}{2}|{3}{4}{5}|{6}{7}{8}", midCubies3.ElementAt(0), midCubies3.ElementAt(1), midCubies3.ElementAt(2),
                midCubies3.ElementAt(3), midCubies3.ElementAt(4), midCubies3.ElementAt(5),
                midCubies3.ElementAt(6), midCubies3.ElementAt(7), midCubies3.ElementAt(8));
            System.Console.WriteLine("    ---   ");

            // Untere Reihe
            List<CubieColor> bottomCubies = this.cubies.Where(q => q.PosZ == -1).OrderByDescending(q => q.PosX).ThenBy(q => q.PosY).Select(q => q.ColZ).ToList();
            System.Console.WriteLine("    {0}{1}{2}   ", bottomCubies.ElementAt(0), bottomCubies.ElementAt(1), bottomCubies.ElementAt(2));
            System.Console.WriteLine("    {0}{1}{2}   ", bottomCubies.ElementAt(3), bottomCubies.ElementAt(4), bottomCubies.ElementAt(5));
            System.Console.WriteLine("    {0}{1}{2}   ", bottomCubies.ElementAt(6), bottomCubies.ElementAt(7), bottomCubies.ElementAt(8));
            System.Console.WriteLine("    ---   ");

            // Hintere Reihe
            List<CubieColor> backCubies = this.cubies.Where(q => q.PosX == -1).OrderBy(q => q.PosZ).ThenBy(q => q.PosY).Select(q => q.ColX).ToList();
            System.Console.WriteLine("    {0}{1}{2}   ", backCubies.ElementAt(0), backCubies.ElementAt(1), backCubies.ElementAt(2));
            System.Console.WriteLine("    {0}{1}{2}   ", backCubies.ElementAt(3), backCubies.ElementAt(4), backCubies.ElementAt(5));
            System.Console.WriteLine("    {0}{1}{2}   ", backCubies.ElementAt(6), backCubies.ElementAt(7), backCubies.ElementAt(8));

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

                case CubeSurface.Middle:
                    cubies = this.cubies.Where(q => q.PosZ == 0).ToList();
                    break;

                default:
                    cubies = null;
                    break;
            }

            return cubies;
        }

        public Cubie getCubie(CubieColor col1, CubieColor col2, CubieColor col3)
        {
            Cubie cube = this.cubies.Where(q =>((q.ColX == col1 && q.ColY == col2 && q.ColZ == col3) ||
                                                (q.ColX == col1 && q.ColY == col3 && q.ColZ == col2) ||
                                                (q.ColX == col2 && q.ColY == col1 && q.ColZ == col3) ||
                                                (q.ColX == col2 && q.ColY == col3 && q.ColZ == col1) ||
                                                (q.ColX == col3 && q.ColY == col1 && q.ColZ == col2) ||
                                                (q.ColX == col3 && q.ColY == col2 && q.ColZ == col1))).Select(q=> q).FirstOrDefault();
            return cube;
        }

        public Cubie getCubie(int posX, int posY, int posZ)
        {
            return this.cubies.Where(q => q.PosX == posX && q.PosY == posY && q.PosZ == posZ).Select(q => q).FirstOrDefault();
        }
    }
}
